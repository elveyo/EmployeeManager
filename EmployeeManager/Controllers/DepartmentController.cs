using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers;

public class DepartmentController : Controller
{


    public IActionResult Index()
    {
        var response = new DepartmentIndexVM(){Departments= Store.DepartmentStore};   
        return View(response);
    }

    [HttpPost]
    public IActionResult Add()
    {
        return View();
    }
}