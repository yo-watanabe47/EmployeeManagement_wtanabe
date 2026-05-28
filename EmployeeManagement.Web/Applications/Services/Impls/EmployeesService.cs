using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;
/// <summary>
/// 商品登録サービスインターフェイスの実装
/// </summary>



public class EmployeesService : IEmployeesService
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly AppDbContext _context;
    public EmployeesService(AppDbContext context, IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
        _context = context;
    }
    public List<Employees> GetEmployees()
    {
        return _employeesRepository.FindAll();

    }

 public void EnterEmployee(Employees employee)
    {
        try
        {
            _context.Database.BeginTransaction();
            _employeesRepository.Create(employee);
            _context.Database.CommitTransaction();
            
        }catch 
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}