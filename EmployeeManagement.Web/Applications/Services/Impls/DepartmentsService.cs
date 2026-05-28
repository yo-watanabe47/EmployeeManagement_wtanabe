using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;
/// <summary>
/// 部門登録サービスインターフェイスの実装
/// </summary>



public class DepartmentsService : IDepartmentsService
{
    private readonly IDepartmentsRepository _departmentsRepository;
    private readonly AppDbContext _context;
    public DepartmentsService(AppDbContext context, IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
        _context = context;
    }
    
    public List<Departments> GetDepartments()
    {
        return _departmentsRepository.FindAll();

    }

    public void EnterDepartment(Departments department)
    {
        try
        {
            _context.Database.BeginTransaction();
            _departmentsRepository.Create(department);
            _context.Database.CommitTransaction();
            
        }catch 
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }
        public void Exists(string deptName)
    {
        var exists = _departmentsRepository.ExistsByDeptName(deptName);
        if (exists)
        {
            throw new ExistsException($"部門名:{deptName}は既に存在します。");
        }
    }
}