using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Presentations.ViewModels;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// 部門情報コントローラ
/// </summary>

public class DepartmentsController : Controller
{
    private readonly IDepartmentsService _service;

    public DepartmentsController(IDepartmentsService service )
    {
        _service = service;
    }
[Route("List")]

    public IActionResult List()
    {
        try
        {
            var departments = _service.GetDepartments();
            var viewModels = departments.Select(dept => new DepartmentsViewModel
            {
                Id = dept.Id,
                DeptName = dept.Dept_name,
                CreatedAt = dept.Created_at,
                CreatedEmpNo = dept.Created_emp_no,
                UpdatedAt = dept.Updated_at,
                UpdatedEmpNo = dept.Updated_emp_no
            }).ToList();
            return View(viewModels);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Error", "Home");
        }
    }
}