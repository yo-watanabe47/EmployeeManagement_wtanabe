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
public class DepartmentsEntityAdapter :
IRestorer<Departments, DepartmentsEntity>
{

public Departments Restore(DepartmentsEntity target)
    {
        var departments = new Departments(target.Id, target.DeptName, target.CreatedAt, target.CreatedEmpNo, target.UpdatedAt, target.UpdatedEmpNo);
        return departments;
    }
}