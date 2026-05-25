using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Presentations.ViewModels;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// 商品登録コントローラ
/// </summary>
[Route("Department")]
public class DepartmentsController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<DepartmentsController> _logger;
    /// <summary>
    /// 部門登録Serviceインターフェイス
    /// </summary>
    private readonly IDeptRegisterService _service;
    /// <summary>
    /// DepartmentsViewModelからDeptに変換するアダプタ
    /// </summary>
    private readonly DepartmentsViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<DepartmentsViewModel> _tempDataStore;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="service">部門登録Serviceインターフェイス</param>
    /// <param name="adapter">DepartmentsViewModelからDeptに変換するアダプタ</param>
    /// <param name="tempDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    /// <summary>
    public DepartmentsController(
        ILogger<DepartmentsController> logger,
        IDeptRegisterService service,
        DepartmentsViewModelAdapter adapter,
        TempDataStore<DepartmentsViewModel> tempDataStore)
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
    DepartmentsViewModel? viewModel = null;
    // [戻る]ボタンへの対応
    // TempDataからItemRegisterViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // 商品登録ViewModelを生成する
        viewModel = new DepartmentsViewModel();
    }
    // viewModelをviewに渡して画面表示する
    return View(viewModel);
 } 


 /// <summary>
/// 入力画面の[完了]ボタンクリックアクションメソッド
/// </summary>
/// <param name="viewModel"></param>
/// <returns></returns>
[HttpPost("Confirm")]
public IActionResult Confirm(DepartmentsViewModel viewModel)
{
    // バリデーションチェック
    if (!ModelState.IsValid) // バリデーションエラーあり
   {
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
        return View("Enter", viewModel);
    }

    // 確認画面を表示
    return View(viewModel);
}
/// <summary>
/// 確認画面の[戻る]ボタンクリックアクションメソッド
/// </summary>
/// <returns></returns>
[HttpPost("Back")]
public IActionResult Back(DepartmentsViewModel viewModel)
{
    _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
    // DepartmentsViewModelをシリアライズして、TempDataに保存する
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
public IActionResult Register(DepartmentsViewModel viewModel)
{
    // DepartmentsViewModelをシリアライズして、TempDataに保存する
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
    DepartmentsViewModel? viewModel = null;
    // TempDataからDepartmentsViewModelを取得する
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        // データが存在しない場合、入力画面にリダイレクト
        return RedirectToAction("Enter");
    }
    _logger.LogInformation("商品登録処理を開始");
    // DepartmentsFormをドメインモデル:Itemに変換する
    var item = _adapter.Restore(viewModel!);
    // 新しい商品を登録する
    _service.Register(item);
    return View(viewModel);
}
}