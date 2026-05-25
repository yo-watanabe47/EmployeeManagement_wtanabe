using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:DeptとDeptEntityの相互変換Adapter
/// </summary>
/// <typeparam name="TDomain">Dept</typeparam>
/// <typeparam name="TTarget">DeptEntity</typeparam>
public class DeptEntityAdapter :
IConverter<Dept, DeptEntity>, IRestorer<Dept, DeptEntity>
{
    /// <summary>
    /// ドメインオブジェクト:DeptをDeptEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインオブジェクト:Dept</param>
    /// <returns>変換結果</returns>
    public DeptEntity Convert(Dept domain)
    {
        if (domain == null)
        {
            throw new InternalException("引数domainがnullのため変換できません。");
        }
        return new DeptEntity
        {
            //Id = domain.Id ?? 0,
            Name = domain.Name,
        };
    }

    /// <summary>
    ///  DeptEntityからドメインオブジェクト:Deptを復元する
    /// </summary>
    /// <typeparam name="target">DeptEntity</typeparam>
    /// <returns>ドメインオブジェクト:Dept</returns>
    public Dept Restore(DeptEntity target)
    {
        if (target == null)
        {
            throw new InternalException("引数targetがnullのため復元できません。");
        }
        var domain = new Dept(target.Id, target.Name);
        return domain;
    }
}