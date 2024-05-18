using EmployeeManager.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Web.ViewModals;

public class EmployeeAddVM
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }
    public string Username {  get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    

}