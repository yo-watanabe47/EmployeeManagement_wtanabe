using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;
/// <summary>
/// 部門登録ユースケース用ViewModelクラス
/// </summary>
public class DepartmentsViewModel
{
    /// <summary>
    /// 部門名
    /// </summary>
    [Required(ErrorMessage = "部門名は必須です。")]
    [StringLength(50, ErrorMessage = "部門名は50文字以内で入力してください。")]
    [Display(Name = "部門名")]
    public string? Name { get; set; }

}