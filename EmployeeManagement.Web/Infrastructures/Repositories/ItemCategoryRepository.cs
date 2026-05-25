using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:商品カテゴリのCRUD操作インターフェイスの実装
/// </summary>
public class ItemCategoryRepository : IItemCategoryRepository
{
    // DbContext継承クラス
    private readonly AppDbContext _appDbContext;
    // ItemCategroyとItemCategoryEntityの相互変換
    private readonly ItemCategoryEntityAdapter _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="adapter">ItemCategroyとItemCategoryEntityの相互変換</param>
    public ItemCategoryRepository(
        AppDbContext appDbContext ,ItemCategoryEntityAdapter adapter)
    {
        _appDbContext = appDbContext;
        _adapter = adapter;
    }

    /// <summary>
    /// すべての商品カテゴリを取得する
    /// </summary>
    /// <returns>すべての商品カテゴリ</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public List<ItemCategory> FindAll()
    {
        try
        {
            // すべての商品カテゴリを取得する
            var entities = _appDbContext.ItemCategories
                .AsNoTracking().ToList();
            // ItemCategoryのリストを作成する
            var itemCategories = new List<ItemCategory>();
            // 取得したEntityからドメインオブジェクトを復元してリストに追加する
            foreach (var entity in entities)
            {
                itemCategories.Add(_adapter.Restore(entity));
            }
            return itemCategories;
        }
        catch (Exception e)
        {
            throw new InternalException(
                "すべての商品カテゴリを取得できませんでした。", e);
        }
    }
    /// <summary>
    /// 引数Idに一致する商品カテゴリを取得する
    /// </summary>
    /// <param name="id">商品カテゴリId</param>
    /// <returns>該当商品カテゴリ</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public ItemCategory? FindById(int id)
    {
        try
        {
            // Idで商品カテゴリを取得する
            var entity = _appDbContext.ItemCategories
            .Where(c => c.Id == id).FirstOrDefault();
            // 存在しない場合はnullを返す
            if (entity == null)
            {
                return null;
            }
            // 取得したEntityからドメインオブジェクトを復元して返す
            return _adapter.Restore(entity);
        }
        catch (Exception e)
        {
            throw new InternalException(
                "引数Idに一致する商品カテゴリを取得できませんでした。", e);
        }
    }
}