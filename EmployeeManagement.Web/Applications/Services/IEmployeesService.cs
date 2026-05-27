using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;
/// <summary>
/// 商品登録サービスインターフェイス
/// </summary>
public interface IEmployeesService
{
       List<Employees> GetEmployees();
       void EnterEmployee(Employees employee);
}