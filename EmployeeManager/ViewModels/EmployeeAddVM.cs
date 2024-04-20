using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Web.ViewModals;

public class EmployeeAddVM
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public int DepartmentId { get; set; }
    
    
    //this is list of departments shown on Add Employee form
    public List<SelectListItem> Departments { get; set; }

    public EmployeeAddVM()
    {
        Departments = new List<SelectListItem>();
    }
}