using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイス
/// </summary>
public interface IEmployeesRepository
{
  List<Employees> FindAll();
  void Create(Employees employee);
  bool ExistsByEmpNo(string employee_No);
}