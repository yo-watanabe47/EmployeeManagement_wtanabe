using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:ItemとItemEntityの相互変換Adapter
/// </summary>
/// <typeparam name="TDomain">Item</typeparam>
/// <typeparam name="TTarget">ItemEntity</typeparam>
public class ItemEntityAdapter :
IConverter<Item, ItemEntity>, IRestorer<Item, ItemEntity>
{
    /// <summary>
    /// ドメインオブジェクト:ItemをItemEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインオブジェクト:Item</param>
    /// <returns>変換結果</returns>
    public ItemEntity Convert(Item domain)
    {
        if (domain == null)
        {
            throw new InternalException("引数domainがnullのため変換できません。");
        }
        return new ItemEntity
        {
            //Id = domain.Id ?? 0,
            Name = domain.Name,
            Price = domain.Price,                 // nullはnullのまま
            CategoryId = domain.ItemCategory?.Id,  // null安全
            Category = null,
            Stock = null
        };
    }

    /// <summary>
    ///  ItemEntityからドメインオブジェクト:Itemを復元する
    /// </summary>
    /// <typeparam name="target">ItemEntity</typeparam>
    /// <returns>ドメインオブジェクト:Item</returns>
    public Item Restore(ItemEntity target)
    {
        if (target == null)
        {
            throw new InternalException("引数targetがnullのため復元できません。");
        }
        var domain = new Item(target.Id, target.Name, target.Price);
        return domain;
    }
}