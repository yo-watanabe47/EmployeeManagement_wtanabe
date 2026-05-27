using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Presentations.ViewModels;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// 従業員情報コントローラ
/// </summary>

public class EmployeesController : Controller
{
    private readonly IEmployeesService _service;
    private readonly EmployeesViewModelAdapter _adapter;

    public EmployeesController(IEmployeesService service, EmployeesViewModelAdapter adapter)
    {
        _service = service;
        _adapter = adapter;
    }
[Route("EmployeesView")]

    public IActionResult EmployeesView()
    {
        try
        {
            var employees = _service.GetEmployees();
            var viewModels = _adapter.Convert(employees);
            return View(viewModels);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Error", "Home");
        }
    }
    [HttpGet("EmployeesEnter")]
    public IActionResult EmployeesEnter()
    {
        return View();
     } 

[HttpPost("EmployeesEnter")]
    public IActionResult EmployeesEnter(EmployeesEnterViewModel viewModel)
    {
    var employees = _adapter.Restore(viewModel);
    _service.EnterEmployee(employees);
    return RedirectToAction("EmployeesView");
    } 
}