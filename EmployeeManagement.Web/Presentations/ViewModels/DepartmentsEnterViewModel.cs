using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class DepartmentsEnterViewModel
{
        [Required(ErrorMessage = "部門名は必須です。")]
        [StringLength(50, ErrorMessage = "部門名は50文字以内で入力してください。")]
        [Display(Name = "部門名")]
        public string? DeptName { get; init; }

        
        public DateTime? CreatedAt { get; init; }
        
        [Required(ErrorMessage = "作成者IDは必須です。")]
        [StringLength(10, ErrorMessage = "作成者IDは10文字以内で入力してください。")]
        [Display(Name = "作成者ID")]
        public string? CreatedEmpNo { get; init; }
}