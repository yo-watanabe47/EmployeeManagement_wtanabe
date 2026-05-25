using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 商品登録ユースケース用ViewModelから
/// ドメインオブジェクト:Item、ItemCategory、ItemStockへ変換するAdapterクラス
/// </summary>
public class ItemRegisterViewModelAdapter : IRestorer<Item, ItemRegisterViewModel>
{
    /// <summary>
    /// ItemRegisterViewModel(商品登録ViewModel)を
    /// ドメインオブジェクト:Itemに変換するアダプターインターフェイスの実装
    /// </summary>
    /// <typeparam name="TDomain">Item</typeparam>
    /// <typeparam name="TTarget">ItemRegisterViewModel</typeparam>
    public Item Restore(ItemRegisterViewModel target)
    {
        // ItemStock(商品在庫)を生成する
        var stock = new ItemStock(target.Stock ?? 0);
        // ItemCategory(商品カテゴリ)を生成する
        var category = new ItemCategory(target.CategoryId, target.CategoryName);
        // Item(商品)を生成する
        var item = new Item(target.Name, target.Price ?? 0);
        // ItemCategory(商品カテゴリ)を設定する
        item.ChangeItemCategory(category);
        // ItemStock(商品在庫)を設定する
        item.ChangeStock(stock);
        return item;
    }
}