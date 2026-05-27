using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 部門登録ユースケース用ViewModelから
/// ドメインオブジェクト:Item、ItemCategory、ItemStockへ変換するAdapterクラス
/// </summary>
public class EmployeesViewModelAdapter : IRestorer<Employees, EmployeesEnterViewModel>
{
    /// <summary>
    /// EmployeesViewModel(社員情報ViewModel)を
    /// ドメインオブジェクト:Employeesに変換するアダプターインターフェイスの実装
    /// </summary>
    /// <typeparam name="TDomain">Employees</typeparam>
    /// <typeparam name="TTarget">EmployeesViewModel</typeparam>
    public Employees Restore(EmployeesEnterViewModel target)
    {

        var employees = new Employees(
            target.EmployeeNo,
            target.Name,
            target.Birthday,
            target.Email,
            target.HireDate,
            target.DeptId,
            target.Status,
            target.CreatedAt,
            target.CreatedEmpNo
        );
        return employees;
    }

    public List<EmployeesViewModel> Convert(List<Employees> employees)
{
    return employees.Select(emp => new EmployeesViewModel
    {
                Id = emp.Id ?? 0,
                EmployeeNo = emp.Employee_No,
                Name = emp.Name,
                Birthday = emp.Birthday,
                Email = emp.Email,
                HireDate = emp.HireDate,
                DeptId = emp.DeptId,
                DeptName = emp.DeptName,
                Status = emp.Status,
                CreatedAt = emp.Created_at,
                CreatedEmpNo = emp.Created_emp_no,
                UpdatedAt = emp.Updated_at,
                UpdatedEmpNo = emp.Updated_emp_no
        }).ToList();
}
}