using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 商品登録ユースケース用ViewModelから
/// ドメインオブジェクト:Item、ItemCategory、ItemStockへ変換するAdapterクラス
/// </summary>
public class DepartmentsViewModelAdapter : IRestorer<Dept, DepartmentsViewModel>
{
    /// <summary>
    /// DepartmentsViewModel(部門ViewModel)を
    /// ドメインオブジェクト:Itemに変換するアダプターインターフェイスの実装
    /// </summary>
    /// <typeparam name="TDomain">Item</typeparam>
    /// <typeparam name="TTarget">DepartmentsViewModel</typeparam>
    public Dept Restore(DepartmentsViewModel target)
    {
        // Dept(部門)を生成する
        var dept = new Dept(target.Name);

        return dept;
    }
}