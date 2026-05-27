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
    private readonly DepartmentsViewModelAdapter _adapter;

    public DepartmentsController(IDepartmentsService service, DepartmentsViewModelAdapter adapter)
    {
        _service = service;
        _adapter = adapter;
    }
[Route("DepartmentsView")]

    public IActionResult DepartmentsView()
    {
        try
        {
            var departments = _service.GetDepartments();
            var viewModels = _adapter.Convert(departments);
            return View(viewModels);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Error", "Home");
        }
    }
[HttpGet("DepartmentsEnter")]
    public IActionResult DepartmentsEnter()
    {
        return View();
     } 

[HttpPost("DepartmentsEnter")]
    public IActionResult DepartmentsEnter(DepartmentsEnterViewModel viewModel)
    {
    var departments = _adapter.Restore(viewModel);
    _service.EnterDepartment(departments);
    return RedirectToAction("DepartmentsView");
    } 


}