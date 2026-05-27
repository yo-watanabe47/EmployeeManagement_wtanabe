using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:ItemとItemEntityの相互変換Adapter
/// </summary>
/// <typeparam name="TDomain">Item</typeparam>
/// <typeparam name="TTarget">ItemEntity</typeparam>
public class EmployeesEntityAdapter :
IRestorer<Employees, EmployeesEntity>
{

    public Employees Restore(EmployeesEntity target)
    {
        var employees = new Employees(
            target.Id,
            target.EmployeeNo,
            target.Name, 
            target.Birthday,
            target.Email,
            target.HireDate, 
            target.DeptId,
            target.Status,
            target.CreatedAt,
            target.CreatedEmpNo,
            target.UpdatedAt,
            target.UpdatedEmpNo,
            target.Departments?.DeptName
             );
        return employees;
    }

    public EmployeesEntity Convert(Employees domain)
    {
        if (domain == null)
        {
            throw new InternalException("引数domainがnullのため変換できません。");
        }
        return new EmployeesEntity
        {
        Id = domain.Id,
        EmployeeNo = domain.EmployeeNo,
        Name = domain.Name,
        Birthday = domain.Birthday,
        Email = domain.Email,
        HireDate = domain.HireDate,
        DeptId = domain.DeptId,
        Status = domain.Status,
        Createdat = domain.Created_at,
        CreatedEmpNo = domain.Created_emp_no,
        Updatedat = domain.Updated_at,
        UpdatedEmpNo = domain.Updated_emp_no,
        DeptName = domain.DeptName,
        };
    }
}