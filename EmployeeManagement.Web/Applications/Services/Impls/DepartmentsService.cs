using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;
/// <summary>
/// 商品登録サービスインターフェイスの実装
/// </summary>



public class DepartmentsService : IDepartmentsService
{
    private readonly IDepartmentsRepository _departmentsRepository;
    public DepartmentsService(AppDbContext context, IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }
    public List<Departments> GetDepartments()
    {
        return _departmentsRepository.FindAll();

    }

}