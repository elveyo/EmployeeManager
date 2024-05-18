using EmployeeManager.BusinessLogic;
using EmployeeManager.BusinessLogic.Entities;
using EmployeeManager.BusinessLogic.Services.Departments;
using EmployeeManager.Web.ViewModels.DepartmetsModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers;

public class DepartmentController : Controller
{
    private IDepartmentService _departmentService;

    public DepartmentController( IDepartmentService departmentService)
    {
        _departmentService = departmentService;

    }


    public IActionResult Index()
    {
       var departments = _departmentService.GetDepartments();
        var departmentModel = new DepartmentIndexVM()
        {
            Departments = departments
        };

        return View(departmentModel);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new DepartmentAddVM());

    }

    [HttpPost]
    public IActionResult Add([FromForm] DepartmentAddVM request)
    {
        _departmentService.Create(request.Name, request.Code, request.Description);
        TempData["Success"] = "Department added sucessfully!";
        return RedirectToAction("Index");
    }

    public IActionResult Edit([FromRoute] int id)
    {
        var department = _departmentService.GetById(id);
        var depModel = new DepartmentEditVM()
        {
            Name = department.Name,
            Code = department.Code,
            Description = department.Description
        };


        return View(depModel);
    }

    [HttpPost]
    public IActionResult Edit([FromRoute] int id, [FromForm] DepartmentEditVM request )
    {

        _departmentService.Update(id, request.Name, request.Code, request.Description);
        TempData["Success"] = "Department sucessfully updated";
        return RedirectToAction("Index");

    }

    public  IActionResult Delete([FromRoute]int id)
    {
        _departmentService.Delete(id);
        TempData["Success"] = "Department is successfully deleted"; 
        return RedirectToAction("Index");

    }
}
