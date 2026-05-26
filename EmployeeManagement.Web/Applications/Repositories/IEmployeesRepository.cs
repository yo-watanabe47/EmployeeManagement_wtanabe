using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:商品のCRUD操作インターフェイス
/// </summary>
public interface IEmployeesRepository
{
  List<Employees> FindAll();
}