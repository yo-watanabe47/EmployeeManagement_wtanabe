using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;
/// <summary>
/// 商品在庫テーブル(item_stock)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("item_stock")]
public class ItemStockEntity {
    /// <summary>
    /// 商品在庫Id
    /// </summary>
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    /// <summary>
    /// 在庫数
    /// </summary>
    [Column("stock")]
    public int? Stock { get; set;  }
    /// <summary>
    /// 商品番号
    /// </summary>
    [Column("item_id")]
    public int ItemId { get; set; }  
    /// <summary>
    /// 外部キーで結合する商品
    /// </summary>
    [ForeignKey("ItemId")]
    public ItemEntity? Product { get; set; }
}