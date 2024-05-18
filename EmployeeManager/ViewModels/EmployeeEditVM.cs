    using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Web.ViewModals;

public class EmployeeEditVM
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }

}