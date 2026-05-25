using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 商品登録ユースケース用ViewModelクラス
/// </summary>
public class ItemRegisterViewModel
{
    /// <summary>
    /// 商品名
    /// </summary>
    [Required(ErrorMessage = "商品名は必須です。")]
    [StringLength(30, ErrorMessage = "商品名は30文字以内で入力してください。")]
    [Display(Name = "商品名")]
    public string? Name { get; set; }

    /// <summary>
    /// 単価
    /// </summary>
    [Required(ErrorMessage = "単価は必須です。")]
    [Range(0, int.MaxValue, ErrorMessage = "単価は0以上で入力してください。")]
    [Display(Name = "単価")]
    public int? Price { get; set; }

    /// <summary>
    /// 在庫数
    /// </summary>
    [Required(ErrorMessage = "在庫数は必須です。")]
    [Range(0, int.MaxValue, ErrorMessage = "在庫数は0以上で入力してください。")]
    [Display(Name = "在庫数")]
    public int? Stock { get; set; }

    /// <summary>
    /// 選択された商品カテゴリId
    /// </summary>
    [Required(ErrorMessage = "商品カテゴリを選択してください。")]
    [Display(Name = "商品カテゴリ")]
    public int? CategoryId { get; set; } 

    /// <summary>
    /// 選択されたカテゴリ名
    /// </summary>
    [Display(Name = "カテゴリ名")]
    public string? CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// 商品カテゴリリストをSelectListItemのリストに変換してプロパティに設定する
    /// </summary>
    /// <param name="categories"></param>
    public void SetCategories(List<ItemCategory> categories)
    {
        // SelectListItemのリストを作成
        var selectItems = new List<SelectListItem>();
        // 未選択を表す項目を先頭に追加
        selectItems.Add(new SelectListItem
        {
            Value = "",
            Text = "（選択してください）"
        });
        foreach (var category in categories)
        {
            if (category.Id.HasValue)
            {
                var item = new SelectListItem();
                item.Value = category.Id.Value.ToString();
                item.Text = string.IsNullOrEmpty(category.Name) ? "(名称未設定)" : category.Name;
                selectItems.Add(item);
            }
        }
        Categories = selectItems;
    }
    // 商品カテゴリのリスト
    public List<SelectListItem>? Categories { get; set; } = null;
}