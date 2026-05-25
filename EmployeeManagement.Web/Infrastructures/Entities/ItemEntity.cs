using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;
/// <summary>
/// 商品テーブル(item)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("item")]
public class ItemEntity
{
    /// <summary>
    /// 商品Id
    /// </summary>
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    /// <summary>
    /// 商品名
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }
    /// <summary>
    /// 単価
    /// </summary>
    [Column("price")]
    public int? Price { get; set; }
    /// <summary>
    /// 商品カテゴリId
    /// </summary>
    /// <value></value>
    [Column("category_id")]
    public int? CategoryId { get; set; }
    /// <summary>
    /// 外部で結合する商品カテゴリ
    /// </summary>
    [ForeignKey("CategoryId")]
    public ItemCategoryEntity? Category { get; set; }
    /// <summary>
    /// ナビゲーション（1対1）
    /// 商品在庫
    /// </summary>
    public ItemStockEntity? Stock { get; set; }
}