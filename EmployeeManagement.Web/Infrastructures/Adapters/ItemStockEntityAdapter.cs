using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:ItemStockとItemStockEntityの相互変換Adapter
/// </summary>
/// <typeparam name="TDomain">ItemStock</typeparam>
/// <typeparam name="TTarget">ItemStockEntity</typeparam>
public class ItemStockEntityAdapter :
IConverter<ItemStock, ItemStockEntity>, IRestorer<ItemStock, ItemStockEntity>
{
    /// <summary>
    /// ドメインオブジェクト:ItemStockをItemStockEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインオブジェクト:ItemCategory</param>
    /// <returns>変換結果</returns>
    public ItemStockEntity Convert(ItemStock domain)
    {
        if (domain == null)
        {
            throw new InternalException("引数domainがnullのため変換できません。");
        }
        return new ItemStockEntity
        {
            //Id = domain.Id ?? 0,
            Stock = domain.Stock,
            // ItemIdはDomain側に保持していないので、Repository側で必ずセットする
            // ここでは既定値のまま0する
            ItemId = 0,
            Product = null
        };
    }

    /// <summary>
    ///  ItemStockEntityからドメインオブジェクト:ItemStockを復元する
    /// </summary>
    /// <typeparam name="target">ItemStockEntity</typeparam>
    /// <returns>ドメインオブジェクト:ItemStock</returns>
    public ItemStock Restore(ItemStockEntity target)
    {
        if (target == null)
        {
            throw new InternalException("引数targetがnullのため復元できません。");
        }
        return new ItemStock(target.Id, target.Stock ?? 0);
    }
}