using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class DepartmentsViewModel
{
    public int Id { get; init; }
        public string DeptName { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public string CreatedEmpNo { get; init; } = string.Empty;
        public DateTime? UpdatedAt { get; init; } 
        public string? UpdatedEmpNo { get; init; }


}