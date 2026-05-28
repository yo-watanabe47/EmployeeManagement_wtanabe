using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:商品のCRUD操作インターフェイス
/// </summary>
public interface IDepartmentsRepository
{
  List<Departments> FindAll();
  void Create(Departments department);
  bool ExistsByDeptName(string deptName);
}