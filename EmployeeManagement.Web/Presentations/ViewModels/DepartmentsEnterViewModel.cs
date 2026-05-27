using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Presentations.ViewModels;

public class DepartmentsEnterViewModel
{
        public string DeptName { get; init; } = "";
        public DateTime CreatedAt { get; init; }
        public string CreatedEmpNo { get; init; } = "";
}