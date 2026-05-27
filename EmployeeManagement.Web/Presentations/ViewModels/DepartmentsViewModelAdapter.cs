using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 部門登録ユースケース用ViewModelから
/// ドメインオブジェクト:Item、ItemCategory、ItemStockへ変換するAdapterクラス
/// </summary>
public class DepartmentsViewModelAdapter : IRestorer<Departments, DepartmentsEnterViewModel>
{
    /// <summary>
    /// DepartmentsViewModel(部門情報ViewModel)を
    /// ドメインオブジェクト:Departmentsに変換するアダプターインターフェイスの実装
    /// </summary>
    /// <typeparam name="TDomain">Departments</typeparam>
    /// <typeparam name="TTarget">DepartmentsViewModel</typeparam>
    public Departments Restore(DepartmentsEnterViewModel target)
    {

        var departments = new Departments(
            target.DeptName,
            target.CreatedEmpNo
            );
        return departments;
    }
    public List<DepartmentsViewModel> Convert(List<Departments> departments)
{
    return departments.Select(dept => new DepartmentsViewModel
    {
        Id = dept.Id ?? 0,
        DeptName = dept.Dept_name,
        CreatedAt = dept.Created_at,
        CreatedEmpNo = dept.Created_emp_no,
        UpdatedAt = dept.Updated_at,
        UpdatedEmpNo = dept.Updated_emp_no
    }).ToList();
}
}