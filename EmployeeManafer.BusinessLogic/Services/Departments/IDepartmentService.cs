using EmployeeManager.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Services.Departments
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department GetById(int id);
        void Create(string name, string code, string description);
        void Update(int id, string name, string code, string description);
        void Delete(int id);
    }
}
