using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;
/// <summary>
/// 商品カテゴリテーブル(item_category)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("item_category")]
public class ItemCategoryEntity {
    /// <summary>
    /// 商品カテゴリId
    /// </summary>
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    /// <summary>
    /// 商品カテゴリ名
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }
    /// <summary>
    /// ナビゲーションプロパティ（1対多）
    /// 商品
    /// </summary>
    public List<ItemEntity>? Items { get; set; }
}