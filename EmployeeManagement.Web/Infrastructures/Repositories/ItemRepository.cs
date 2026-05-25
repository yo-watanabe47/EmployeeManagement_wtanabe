using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:商品のCRUD操作インターフェイスの実装
/// </summary>
public class ItemRepository : IItemRepository
{
    // DbContext継承クラス
    private readonly AppDbContext _appDbContext;
    // ItemとItemEntityの相互変換
    private readonly ItemEntityAdapter _itemAdapter;
    // ItemStockとItemStockEntityの相互変換
    private readonly ItemStockEntityAdapter _stockAdapter;
   
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">DbContext継承クラス</param>
    /// <param name="itemAdapter">ItemとItemEntityの相互変換</param>
    /// <param name="stockAdapter">ItemStockとItemStockEntityの相互変換</param>
    public ItemRepository(
        AppDbContext appDbContext, ItemEntityAdapter itemAdapter,
        ItemStockEntityAdapter stockAdapter)
    {
        _appDbContext = appDbContext;
        _itemAdapter = itemAdapter;
        _stockAdapter = stockAdapter;
    }

    /// <summary>
    /// 引数に指定された商品名の存在有無を取得する
    /// </summary>
    /// <param name="name">商品名</param>
    /// <returns>true:存在する false:存在しない</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public bool ExistsByName(string name)
    {
        try
        {
            return _appDbContext.Items.Any(i => i.Name == name);
        }
        catch (Exception e)
        {
            throw new InternalException("引数に指定された商品名の存在有無を取得できませんでした。", e);
        }
    }

    /// <summary>
    /// 引数Idに一致する商品を取得する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>該当商品</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public Item? FindById(int id)
    {
        try
        {
            var entity = _appDbContext.Items
                        .Include(i => i.Stock)
                        .FirstOrDefault(i => i.Id == id);
            if (entity == null)
            {
                return null;
            }
            var item = _itemAdapter.Restore(entity);
            if (entity.Stock != null)
            {
                var stock = _stockAdapter.Restore(entity.Stock);
                stock.ChangeProduct(item);
                item.ChangeStock(stock);
            }
            return item;
        }
        catch (Exception e)
        {
            throw new InternalException("引数Idに一致する商品を取得できませんでした。", e);
        }
    }

    /// <summary>
    /// 商品を永続化する
    /// </summary>
    /// <param name="item">永続化する商品</param>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public void Create(Item item)
    {
        try
        {
            // 1.Itemを永続化する
            var itemEntity = _itemAdapter.Convert(item);
            _appDbContext.Items.Add(itemEntity);
            _appDbContext.SaveChanges(); // 商品Id(主キー)が採番される

            // 2.ItemStock を永続化
            if (item.ItemStock != null)
            {
                var stockEntity = _stockAdapter.Convert(item.ItemStock);
                if (itemEntity.Id == null)
                {
                    throw new Exception("itemEntityが未設定のため、ItemStockEntityにItemIdを設定できません。");
                }
                stockEntity.ItemId = itemEntity.Id.Value; // 採番された商品Idを設定
                _appDbContext.ItemStocks.Add(stockEntity);
                _appDbContext.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new InternalException("商品を永続化できませんでした。", e);
        }
    }
}