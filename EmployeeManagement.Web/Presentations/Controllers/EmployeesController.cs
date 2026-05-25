using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Presentations.ViewModels;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// 商品登録コントローラ
/// </summary>
[Route("ItemRegister")]
public class EmployeesController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<EmployeesController> _logger;
    /// <summary>
    /// 商品登録Serviceインターフェイス
    /// </summary>
    private readonly IDeptRegisterService _service;
    /// <summary>
    /// EmployeesViewModelからItemに変換するアダプタ
    /// </summary>
  ///  private readonly EmployeesViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<EmployeesViewModel> _tempDataStore;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="service">商品登録Serviceインターフェイス</param>
    /// <param name="adapter">EmployeesViewModelからItemに変換するアダプタ</param>
    /// <param name="tempDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    /// <summary>
    public EmployeesController(
        ILogger<EmployeesController> logger,
        IDeptRegisterService service,
      ///  EmployeesViewModelAdapter adapter,
        TempDataStore<EmployeesViewModel> tempDataStore)
    {
        _logger = logger;
        _service = service;
    ///    _adapter = adapter;
        _tempDataStore = tempDataStore;
    }
    /// <summary>
/// 部門登録(入力)画面表示 アクションメソッド
/// </summary>
/// <returns></returns>
[HttpGet("Enter")]
public IActionResult Enter()
{
    EmployeesViewModel? viewModel = null;
    // [戻る]ボタンへの対応
    // TempDataからEmployeesViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // 部門登録ViewModelを生成する
        viewModel = new EmployeesViewModel();
    }
    // 部門カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
    PopulateCategories(viewModel);
    // viewModelをviewに渡して画面表示する
    return View(viewModel);
 } 

/// <summary>
/// 部門カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
/// </summary>
private void PopulateCategories(EmployeesViewModel viewModel)
{
    // 部門登録サービスから部門カテゴリ一覧を取得する
 ///   var categories = _service.GetDeptCategories();
    // 部門カテゴリ一覧をEmployeesViewModelに登録する
 ///   viewModel.SetCategories(categories);
    _logger.LogInformation("部門カテゴリリストを設定");
 }  
 /// <summary>
/// 入力画面の[完了]ボタンクリックアクションメソッド
/// </summary>
/// <param name="viewModel"></param>
/// <returns></returns>
[HttpPost("Confirm")]
public IActionResult Confirm(EmployeesViewModel viewModel)
{
    // バリデーションチェック
    if (!ModelState.IsValid) // バリデーションエラーあり
   {
        // 部門カテゴリ一覧を取得してViewModelに設定する(SelectListItem形式)
        PopulateCategories(viewModel);
        // 入力画面の表示
        return View("Enter", viewModel);
    }

    // 同一部門チェック(部門名で重複判定)
    var name = viewModel.Name?.Trim() ?? string.Empty;
    try
    {
        _service.Exists(name);
    }
    catch (ExistsException e)
    {
        // 部門名フィールドにエラーメッセージを追加
        ModelState.AddModelError(nameof(viewModel.Name), e.Message);
        // SelectListItemを再設定して入力画面へ戻す
        PopulateCategories(viewModel);
        return View("Enter", viewModel);
    }

    // 部門カテゴリの取得
    try
    {
    ///    var deptCategory = _service.GetDeptCategoryById(viewModel.CategoryId ?? 0);
        _logger.LogInformation(
            $"部門カテゴリId:{viewModel.CategoryId ?? 0}の部門カテゴリを取得する");
    ///    viewModel.CategoryName = deptCategory.Name;
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
public IActionResult Back(EmployeesViewModel viewModel)
{
    _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
    // EmployeesViewModelをシリアライズして、TempDataに保存する
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
public IActionResult Register(EmployeesViewModel viewModel)
{
    // EmployeesViewModelをシリアライズして、TempDataに保存する
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
    EmployeesViewModel? viewModel = null;
    // TempDataからEmployeesViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // データが存在しない場合、入力画面にリダイレクト
        return RedirectToAction("Enter");
    }
    _logger.LogInformation("部門登録処理を開始");
    // EmployeesFormをドメインモデル:Deptに変換する
 ///   var dept = _adapter.Restore(viewModel!);
    // 新しい部門を登録する
 ///   _service.Register(dept);
    return View(viewModel);
}
}