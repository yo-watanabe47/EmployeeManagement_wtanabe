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
    public EmployeesService(AppDbContext context, IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }
    public List<Employees> GetEmployees()
    {
        return _employeesRepository.FindAll();

    }

}