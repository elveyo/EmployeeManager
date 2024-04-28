using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using EmployeeManager.Web.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext context) {
            dbContext = context;
        }
        public IActionResult Index()

        {
            var employees = dbContext.Employees
                .Include(x=>x.Department)
                .Select(emp => new EmployeeView
            {
                Id = emp.Id,
                FullName = emp.FirstName + ' ' + emp.LastName,
                Department = emp.Department.Name,

            }).ToList();
            var employeeIndex = new EmployeeIndexVM()
            {
                Employees = employees
            };
            return View(employeeIndex);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var employeeModel = new EmployeeAddVM();
            FillEmployeeViewModel(employeeModel);
            return View(employeeModel);
        }


        [HttpPost]
        public IActionResult Add([FromForm]EmployeeAddVM request)
        {
            //If valdiation fails, we return form again with specific error.
            if (!validateFormData(request))
            {
                FillEmployeeViewModel(request);
                TempData["Error"] = "Enter valid data!";
                return View(request);
            }
            var emp = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                DepartmentId = request.DepartmentId,
                User = new User()
                {
                    Username = "someone",
                    Password = "lol",
                    Email = "lol@gmail.com"
                }
            };
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            TempData["Success"] = "Employee successfully added.";
            return RedirectToAction("Index");
            
        }



        public IActionResult Edit([FromRoute]int id)
        {
            var employee  =dbContext.Employees.First(emp=>emp.Id == id);
            var employeeModel = new EmployeeEditVM()
            {
                Id = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                DepartmentId = employee.DepartmentId
            };
            FillEmployeeEditModel(employeeModel);
            return View(employeeModel);
        }


        [HttpPost]
        public IActionResult Edit([FromRoute]int id,[FromForm] EmployeeEditVM request)

        {

            var employee = dbContext.Employees.First(emp=>emp.Id == id);
            //updating existing user with new data from form
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.BirthDate = request.BirthDate;
            employee.DepartmentId = request.DepartmentId;
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();

            TempData["Success"] = "You have successfully edited employee";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)      
        {
            var employee = dbContext.Employees.First(emp=>emp.Id==id);
            dbContext.Employees.Remove(employee);
            TempData["Success"] = "You successfully deleted employee.";
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        private void FillEmployeeViewModel(EmployeeAddVM request)
        {
            request.Departments = dbContext.Departments.Select(department => new SelectListItem
            {

                Value = department.Id.ToString(),
                Text = department.Name
            }).ToList();
        }
        private void FillEmployeeEditModel(EmployeeEditVM request)
        {
            request.Departments = dbContext.Departments.Select(department => new SelectListItem
            {

                Value = department.Id.ToString(),
                Text = department.Name
            }).ToList();

        }

        private bool validateFormData(EmployeeAddVM request)
        {
            return !(string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName));
        }
    }
}
