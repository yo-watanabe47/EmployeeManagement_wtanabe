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
    private readonly TempDataStore<EmployeesEnterViewModel> _tempDataStore;

    public EmployeesController(
        IEmployeesService service,
        EmployeesViewModelAdapter adapter,
        TempDataStore<EmployeesEnterViewModel> tempDataStore)
    {
        _service = service;
        _adapter = adapter;
        _tempDataStore = tempDataStore;
    }


[Route("EmployeesView")]
public IActionResult EmployeesView()
    {
        // try
        // {
            var employees = _service.GetEmployees();
            var viewModels = _adapter.Convert(employees);
            return View(viewModels);
        // }
        // catch (Exception ex)
        // {
        //     //TempData["ErrorMessage"] = ex.Message;
        //     //return RedirectToAction("Error", "Home");
        // }
    }


[HttpGet("EmployeesEnter")]
public IActionResult EmployeesEnter()
    {
        EmployeesEnterViewModel? viewModel = null;
        viewModel = _tempDataStore.Load(this);
        return View(viewModel);
     }

[HttpPost("EmployeesBack")]
public IActionResult EmployeesBack(EmployeesEnterViewModel viewModel)
    {
        _tempDataStore.Save(this, viewModel);
        return RedirectToAction("EmployeesEnter");
    } 


[HttpPost("EmployeesConfirm")]
public IActionResult EmployeesConfirm(EmployeesEnterViewModel viewModel)
    {
        if (!ModelState.IsValid)
   {
        return View("EmployeesEnter", viewModel);
    }
    
    var employees_no = viewModel.EmployeeNo?.Trim() ?? string.Empty;
    
    try
    {
        _service.Exists(employees_no);
    }
    catch (ExistsException e)
    {
        ModelState.AddModelError(nameof(viewModel.EmployeeNo), e.Message);
        return View("EmployeesEnter", viewModel);
    }
        return View(viewModel);
     }


[HttpPost("EmployeesRegister")]
public IActionResult EmployeesRegister(EmployeesEnterViewModel viewModel)
    {
        _tempDataStore.Save(this, viewModel);
    return RedirectToAction("EmployeesComplete");
    } 


[HttpGet("EmployeesComplete")]
public IActionResult EmployeesComplete()
{
    EmployeesEnterViewModel? viewModel = null;
    viewModel = _tempDataStore.Load(this);
    if (viewModel == null)
    {
        return RedirectToAction("EmployeesEnter");
    }
    var employees = _adapter.Restore(viewModel);
    _service.EnterEmployee(employees);
    return View(viewModel);
}
}