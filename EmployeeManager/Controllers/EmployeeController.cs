using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {

        public EmployeeController() { }
        public IActionResult Index()

        {
            var response = new EmployeeIndexVM()
            {
                Employees = Store.EmployeeStore
            };
            return View(response);
        }
    }
}
