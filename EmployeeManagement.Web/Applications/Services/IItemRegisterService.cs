using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;
/// <summary>
/// 商品登録サービスインターフェイス
/// </summary>
public interface IItemRegisterService
{
    /// <summary>
    /// 商品カテゴリの一覧を取得する
    /// </summary>
    /// <returns>商品カテゴリリスト</returns>
    List<ItemCategory> GetItemCategories();

    /// <summary>
    /// 指定されたIdの商品カテゴリを取得する
    /// </summary>
    /// <param name="id">商品カテゴリ   Id</param>
    /// <returns>該当する商品カテゴリ</returns>
    /// <exception cref="NotFoundExceotioin">存在しない場合にスローする例外</exception>
    ItemCategory GetItemCategoryById(int id);
    

    /// <summary>
    /// 引数に指定された商品名の有無を調べる
    /// </summary>
    /// <param name="name">商品名</param>
    /// <exception cref="ExistsExceotioin">存在する場合にスローする例外</exception>
    void Exists(string name);  
    
    /// <summary>
    /// 商品と在庫を永続化する
    /// </summary>
    /// <param name="item">永続化する商品</param>
    void Register(Item item);
}