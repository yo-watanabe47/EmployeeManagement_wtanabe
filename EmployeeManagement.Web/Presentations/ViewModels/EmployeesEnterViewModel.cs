using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class EmployeesEnterViewModel
{
        [Required(ErrorMessage = "社員番号は必須です。")]
        [StringLength(10, ErrorMessage = "社員番号は10文字以内で入力してください。")]
        [Display(Name = "社員番号")]
        public String EmployeeNo { get; init; } = "";
        
        [Required(ErrorMessage = "氏名は必須です。")]
        [StringLength(50, ErrorMessage = "氏名は50文字以内で入力してください。")]
        [Display(Name = "氏名")]
        public string? Name { get; init; } = "";
       
        [Required(ErrorMessage = "生年月日は必須です。")]
        [Display(Name = "生年月日")]
        public DateOnly Birthday { get; init; }
     
        [Required(ErrorMessage = "メールアドレスは必須です。")]
        [StringLength(100, ErrorMessage = "メールアドレスは100文字以内で入力してください。")]
        [Display(Name = "メールアドレス")]   
        public string Email { get; init; } = "";
      
        [Required(ErrorMessage = "入社日は必須です。")]
        [Display(Name = "入社日")]
        public DateOnly HireDate { get; init; }
      
        [Required(ErrorMessage = "部署IDは必須です。")]
        [Range(1, int.MaxValue, ErrorMessage = "部署IDは1以上で入力してください。")]
        [Display(Name = "部署ID")]  
        public int DeptId { get; init; }
        
        public int Status { get; init; }=1;
        public DateTime CreatedAt { get; init; }
    
        [Required(ErrorMessage = "作成者IDは必須です。")]
        [StringLength(10, ErrorMessage = "作成者IDは10文字以内で入力してください。")]
        [Display(Name = "作成者ID")]    
        public string? CreatedEmpNo { get; init; } = "";
}