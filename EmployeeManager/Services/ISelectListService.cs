using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Web.Services
{
    public interface ISelectListService
    {
       public List<SelectListItem> GetDepartments();
    }
}
