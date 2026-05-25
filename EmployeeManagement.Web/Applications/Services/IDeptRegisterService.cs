using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;
/// <summary>
/// 部門登録サービスインターフェイス
/// </summary>
public interface IDeptRegisterService
{
    /// <summary>
    /// 引数に指定された部門名の有無を調べる
    /// </summary>
    /// <param name="name">部門名</param>
    /// <exception cref="ExistsExceotioin">存在する場合にスローする例外</exception>
    void Exists(string name);  
    
    /// <summary>
    /// 部門を永続化する
    /// </summary>
    /// <param name="dept">永続化する部門</param>
    void Register(Dept dept);
}