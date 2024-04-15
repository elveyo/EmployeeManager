using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers;

public class PositionController : Controller
{
    // GET
    public IActionResult Index()
    {
        var response = new PositionIndexVM()
        {
            Positions = Store.PositionStore
        };
        return View(response);
    }
}