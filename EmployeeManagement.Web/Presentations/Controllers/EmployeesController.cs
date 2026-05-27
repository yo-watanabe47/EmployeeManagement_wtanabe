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

    public EmployeesController(IEmployeesService service )
    {
        _service = service;
    }
[Route("EmployeesView")]

    public IActionResult EmployeesView()
    {
       // try
        //{
            var employees = _service.GetEmployees();
            var viewModels = employees.Select(emp => new EmployeesViewModel
            {
                Id = emp.Id,
                EmployeeNo = emp.Employee_No,
                Name = emp.Name,
                Birthday = emp.Birthday,
                Email = emp.Email,
                HireDate = emp.HireDate,
                DeptId = emp.DeptId,
                DeptName = emp.DeptName,
                Status = emp.Status,
                CreatedAt = emp.Created_at,
                CreatedEmpNo = emp.Created_emp_no,
                UpdatedAt = emp.Updated_at,
                UpdatedEmpNo = emp.Updated_emp_no
            }).ToList();
            return View(viewModels);
       // }
        //catch (Exception ex)
        //{
          //  TempData["ErrorMessage"] = ex.Message;
            //return RedirectToAction("Error", "Home");
        //}
    }
}