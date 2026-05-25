using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;
/// <summary>
/// 商品テーブル(item)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("item")]
public class DeptEntity
{
    /// <summary>
    /// 部門Id
    /// </summary>
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    /// <summary>
    /// 部門名
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }
   
}