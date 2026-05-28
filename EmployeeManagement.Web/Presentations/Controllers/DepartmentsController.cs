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
        DepartmentsEnterViewModel? viewModel = null;
        return View(viewModel);
     }

[HttpPost("DepartmentsBack")]
public IActionResult DepartmentsBack()
    {
        return RedirectToAction("DepartmentsEnter");
    } 


[HttpPost("DepartmentsConfirm")]
public IActionResult DepartmentsConfirm(DepartmentsEnterViewModel viewModel)
    {
        var deptname = viewModel.DeptName?.Trim() ?? string.Empty;
    try
    {
        _service.Exists(deptname);
    }
    catch (ExistsException e)
    {
        ModelState.AddModelError(nameof(viewModel.DeptName), e.Message);
        return View("DepartmentsEnter", viewModel);
    }
        return View(viewModel);
     }


[HttpPost("DepartmentsRegister")]
public IActionResult DepartmentsRegister(DepartmentsEnterViewModel viewModel)
    {

    return RedirectToAction("DepartmentsComplete");
    } 


[HttpGet("DepartmentsComplete")]
public IActionResult DepartmentsComplete()
{
    DepartmentsEnterViewModel? viewModel = null;
    if (viewModel == null)
    {
        return RedirectToAction("DepartmentsEnter");
    }
    var departments = _adapter.Restore(viewModel);
    _service.EnterDepartment(departments);
    return View(viewModel);
}


}