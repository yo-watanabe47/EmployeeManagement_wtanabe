using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:ItemCategoryとItemCategoryEntityの相互変換Adapter
/// </summary>
/// <typeparam name="TDomain">ItemCategory</typeparam>
/// <typeparam name="TTarget">ItemCategoryEntity</typeparam>
public class ItemCategoryEntityAdapter :
IConverter<ItemCategory, ItemCategoryEntity>,IRestorer<ItemCategory, ItemCategoryEntity>
{
    /// <summary>
    /// ドメインオブジェクト:ItemCategoryをItemCategoryEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインオブジェクト:ItemCategory</param>
    /// <returns>変換結果</returns>
    public ItemCategoryEntity Convert(ItemCategory domain)
    {
        if (domain == null) throw new InternalException("引数domainがnullのため変換できません。");
        return new ItemCategoryEntity
        {
            //Id = domain.Id ?? 0,      // null許容（新規は0）
            Name = domain.Name
        };
    }   
    /// <summary>
    ///  ItemCategoryEntityからドメインオブジェクト:ItemCategoryを復元する
    /// </summary>
    /// <typeparam name="target">ItemCategoryEntity</typeparam>
    /// <returns>ドメインオブジェクト:ItemCategory</returns>
    public ItemCategory Restore(ItemCategoryEntity target)
    {
        if (target == null)
        {
            throw new InternalException("引数targetがnullのため復元できません。");
        }
        var domain = new ItemCategory(target.Id, target.Name);
        return domain;
    }
}