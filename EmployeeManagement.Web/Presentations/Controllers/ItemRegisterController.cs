using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Presentations.ViewModels;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// 商品登録コントローラ
/// </summary>
[Route("ItemRegister")]
public class ItemRegisterController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<ItemRegisterController> _logger;
    /// <summary>
    /// 商品登録Serviceインターフェイス
    /// </summary>
    private readonly IItemRegisterService _service;
    /// <summary>
    /// ItemRegisterViewModelからItemに変換するアダプタ
    /// </summary>
    private readonly ItemRegisterViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<ItemRegisterViewModel> _tempDataStore;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="service">商品登録Serviceインターフェイス</param>
    /// <param name="adapter">ItemRegisterViewModelからItemに変換するアダプタ</param>
    /// <param name="tempDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    /// <summary>
    public ItemRegisterController(
        ILogger<ItemRegisterController> logger,
        IItemRegisterService service,
        ItemRegisterViewModelAdapter adapter,
        TempDataStore<ItemRegisterViewModel> tempDataStore)
    {
        _logger = logger;
        _service = service;
        _adapter = adapter;
        _tempDataStore = tempDataStore;
    }
    /// <summary>
/// 商品登録(入力)画面表示 アクションメソッド
/// </summary>
/// <returns></returns>
[HttpGet("Enter")]
public IActionResult Enter()
{
    ItemRegisterViewModel? viewModel = null;
    // [戻る]ボタンへの対応
    // TempDataからItemRegisterViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // 商品登録ViewModelを生成する
        viewModel = new ItemRegisterViewModel();
    }
    // 商品カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
    PopulateCategories(viewModel);
    // viewModelをviewに渡して画面表示する
    return View(viewModel);
 } 

/// <summary>
/// 商品カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
/// </summary>
private void PopulateCategories(ItemRegisterViewModel viewModel)
{
    // 商品登録サービスから商品カテゴリ一覧を取得する
    var categories = _service.GetItemCategories();
    // 商品カテゴリ一覧をItemRegisterViewModelに登録する
    viewModel.SetCategories(categories);
    _logger.LogInformation("商品カテゴリリストを設定");
 }  
 /// <summary>
/// 入力画面の[完了]ボタンクリックアクションメソッド
/// </summary>
/// <param name="viewModel"></param>
/// <returns></returns>
[HttpPost("Confirm")]
public IActionResult Confirm(ItemRegisterViewModel viewModel)
{
    // バリデーションチェック
    if (!ModelState.IsValid) // バリデーションエラーあり
   {
        // 商品カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
        PopulateCategories(viewModel);
        // 入力画面の表示
        return View("Enter", viewModel);
    }

    // 同一商品チェック(商品名で重複判定)
    var name = viewModel.Name?.Trim() ?? string.Empty;
    try
    {
        _service.Exists(name);
    }
    catch (ExistsException e)
    {
        // 商品名フィールドにエラーメッセージを追加
        ModelState.AddModelError(nameof(viewModel.Name), e.Message);
        // SelectListItemを再設定して入力画面へ戻す
        PopulateCategories(viewModel);
        return View("Enter", viewModel);
    }

    // 商品カテゴリの取得
    try
    {
        var itemCategory = _service.GetItemCategoryById(viewModel.CategoryId ?? 0);
        _logger.LogInformation(
            $"商品カテゴリId:{viewModel.CategoryId ?? 0}の商品カテゴリを取得する");
        viewModel.CategoryName = itemCategory.Name;
    }
    catch (NotFoundException e)
    {
        // カテゴリ未存在エラーを画面に表示
        ModelState.AddModelError(nameof(viewModel.CategoryId), e.Message);
        // プルダウン再設定
        PopulateCategories(viewModel);
        // 入力画面へ戻す
        return View("Enter", viewModel);
    }
    return View(viewModel);
}
/// <summary>
/// 確認画面の[戻る]ボタンクリックアクションメソッド
/// </summary>
/// <returns></returns>
[HttpPost("Back")]
public IActionResult Back(ItemRegisterViewModel viewModel)
{
    _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
    // ItemRegisterViewModelをシリアライズして、TempDataに保存する
    _tempDataStore.Save(this, viewModel);
    // 入力画面を出力するアクションメソッドにリダイレクトする
    return RedirectToAction("Enter");
}
/// <summary>
/// 確認画面の[登録]ボタンクリックアクションメソッド
/// </summary>
/// <param name="viewmodel"></param>
/// <returns></returns>
[HttpPost("Register")]
public IActionResult Register(ItemRegisterViewModel viewModel)
{
    // ItemRegisterViewModelをシリアライズして、TempDataに保存する
    _tempDataStore.Save(this, viewModel);
    // 登録処理GETアクションメソッドにリダイレクトする
    return RedirectToAction("Complete");
}   
/// <summary>
/// アクションメソッド:Register()のリダイレクト先
/// PRGパターン
/// </summary>
/// <returns></returns>
[HttpGet("Complete")]
public IActionResult Complete()
{
    ItemRegisterViewModel? viewModel = null;
    // TempDataからItemRegisterViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // データが存在しない場合、入力画面にリダイレクト
        return RedirectToAction("Enter");
    }
    _logger.LogInformation("商品登録処理を開始");
    // ItemRegisterFormをドメインモデル:Itemに変換する
    var item = _adapter.Restore(viewModel!);
    // 新しい商品を登録する
    _service.Register(item);
    return View(viewModel);
}
}