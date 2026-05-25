using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:商品のCRUD操作インターフェイス
/// </summary>
public interface IItemRepository
{
    /// <summary>
    /// 引数Idに一致する商品を取得する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>該当商品</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    Item? FindById(int id);
    
    /// <summary>
    /// 引数に指定された商品名の存在有無を取得する
    /// </summary>
    /// <param name="name">商品名</param>
    /// <returns>true:存在する false:存在しない</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    bool ExistsByName(string name);

    /// <summary>
    /// 商品を永続化する
    /// </summary>
    /// <param name="itemCategory">永続化する商品</param>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    void Create(Item item);
}