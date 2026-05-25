using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:商品カテゴリのCRUD操作インターフェイス
/// </summary>
public interface IItemCategoryRepository
{
    /// <summary>
    /// すべての商品カテゴリを取得する
    /// </summary>
    /// <returns>すべての商品カテゴリ</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    List<ItemCategory> FindAll();

    /// <summary>
    /// 引数Idに一致する商品カテゴリを取得する
    /// </summary>
    /// <param name="id">商品カテゴリId</param>
    /// <returns>該当商品カテゴリ</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    ItemCategory? FindById(int id);
}