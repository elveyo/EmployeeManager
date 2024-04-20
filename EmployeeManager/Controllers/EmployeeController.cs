using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using EmployeeManager.Web.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {

        public EmployeeController() { }
        public IActionResult Index()

        {
            var employees = Store.EmployeeStore.Select(emp => new EmployeeView
            {
                Id = emp.Id,
                FullName = emp.FirstName + ' ' + emp.LastName,
                Department = Store.DepartmentStore.First(dep => dep.Id == emp.DepartmentId).Name

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

            Store.EmployeeStore.Add(new Employee()
            {
                Id = ++Store.EmployeeID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                DepartmentId = request.DepartmentId
            });

            TempData["Success"] = "Employee successfully added.";
            return RedirectToAction("Index");
            
        }



        public IActionResult Edit([FromRoute]int id)
        {
            var employee  =Store.EmployeeStore.First(emp=>emp.Id == id);
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

            var employee = Store.EmployeeStore.First(emp=>emp.Id == id);
            //updating existing user with new data from form
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.BirthDate = request.BirthDate;
            employee.DepartmentId = request.DepartmentId;

            TempData["Success"] = "You have successfully edited employee";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)      
        {
            var employee = Store.EmployeeStore.First(emp=>emp.Id==id);
            Store.EmployeeStore.Remove(employee);
            TempData["Success"] = "You successfully deleted employee.";
            return RedirectToAction("Index");
        }
        private void FillEmployeeViewModel(EmployeeAddVM request)
        {
            request.Departments = Store.DepartmentStore.Select(department => new SelectListItem
            {

                Value = department.Id.ToString(),
                Text = department.Name
            }).ToList();
        }
        private void FillEmployeeEditModel(EmployeeEditVM request)
        {
            request.Departments = Store.DepartmentStore.Select(department => new SelectListItem
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
