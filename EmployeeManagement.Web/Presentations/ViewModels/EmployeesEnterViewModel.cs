using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class EmployeesEnterViewModel
{
        public int EmployeeNo { get; init; }
        public string Name { get; init; } = "";
        public DateOnly Birthday { get; init; }
        public string Email { get; init; } = "";
        public DateOnly HireDate { get; init; }
        public int DeptId { get; init; }
        public int Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public string CreatedEmpNo { get; init; } = "";
}