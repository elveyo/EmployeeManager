using EmployeeManager.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Web.Services
{
    public class SelectListService : ISelectListService
    {
        private ApplicationDBContext _context;

        public SelectListService(ApplicationDBContext context) {
            _context = context;
        }
        public List<SelectListItem> GetDepartments()
        {
            var list = _context.Departments.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
            return list;

        }
    }
}
