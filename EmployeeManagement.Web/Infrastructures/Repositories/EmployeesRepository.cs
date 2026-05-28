using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイスの実装
/// </summary>
public class EmployeesRepository : IEmployeesRepository
{
    // DbContext継承クラス
    private readonly AppDbContext _appDbContext;
    // ItemとItemEntityの相互変換
    private readonly EmployeesEntityAdapter _employeesAdapter;
   
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">DbContext継承クラス</param>
    /// <param name="employeesAdapter">EmployeesとEmployeesEntityの相互変換</param>
    /// <param name="stockAdapter">ItemStockとItemStockEntityの相互変換</param>
    public EmployeesRepository(
        AppDbContext appDbContext, EmployeesEntityAdapter employeesAdapter)
    {
        _appDbContext = appDbContext;
        _employeesAdapter = employeesAdapter;
    }
    public List<Employees> FindAll()
    {
        var employeesEntities = _appDbContext.Employees
            .Include(e => e.Departments) 
            .ToList();
        var employees = employeesEntities.Select(entity => _employeesAdapter.Restore(entity)).ToList();
        return employees;
    }
    
    public void Create(Employees employee)
    {
        var employeesEntity = _employeesAdapter.Convert(employee);
        _appDbContext.Employees.Add(employeesEntity);
        _appDbContext.SaveChanges();
    }
    public bool ExistsByEmpNo(string employee_No)
    {
        return _appDbContext.Employees.Any(e => e.EmployeeNo == employee_No);
    }

}