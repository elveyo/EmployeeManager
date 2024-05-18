using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using EmployeeManager.BusinessLogic.Services.Employees;
using EmployeeManager.BusinessLogic.Services.Employees;
using EmployeeManager.Web.ViewModals;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IValidator<EmployeeAddVM> addEmployeeValidator;
        private readonly IEmployeeService employeeServise;

        public EmployeeController(

            ApplicationDBContext context,
            IValidator<EmployeeAddVM> employeeAddVMValidator,
            IEmployeeService employeeServise

            ) {

            dbContext = context;
            addEmployeeValidator = employeeAddVMValidator;
            this.employeeServise = employeeServise;
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
            return View(new EmployeeAddVM());
        }


        [HttpPost]
        public IActionResult Add([FromForm]EmployeeAddVM request)
        {
            var validation = addEmployeeValidator.Validate(request);
            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
    {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(request);
            }
            employeeServise.Create(request.Username, request.Password, request.Email, request.FirstName,request.LastName,request.BirthDate, request.DepartmentId);
            
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
            return View(employeeModel);
        }


        [HttpPost]
        public IActionResult Edit([FromRoute]int id,[FromForm] EmployeeEditVM request)

        {

            employeeServise.Update(id, request.FirstName, request.LastName, request.BirthDate, request.DepartmentId);

            TempData["Success"] = "You have successfully edited employee";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)      
        {
            employeeServise.Delete(id);
            TempData["Success"] = "You successfully deleted employee.";
            return RedirectToAction("Index");
        }
       
   

    }
}
