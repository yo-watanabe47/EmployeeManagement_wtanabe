using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class EmployeesViewModel
{
        public int Id { get;  init; }      
        public string EmployeeNo { get;init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public DateOnly Birthday { get; init; }
        public string Email { get; init; } 
        public DateOnly HireDate { get; init; }
        public int DeptId { get; init; } 
        public int Status { get; init; } 
        public DateTime? CreatedAt { get; init; } = DateTime.Now;
        public string CreatedEmpNo { get; init; } = string.Empty;
        public DateTime? UpdatedAt { get; init; } 
        public string? UpdatedEmpNo { get; init; }
        public String DeptName { get; init; } = string.Empty;
        
        public string StatusText
    {
        get
        {
            return Status switch
            {
                1 => "勤務",
                2 => "休職",
                3 => "退職",
                _ => "不明" 
            };
        }
    }
}