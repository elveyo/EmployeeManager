using EmployeeManager.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Services.Employees
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee? GetElementById(int id);
        void Create(string username, string password, string email, string firstname, string lastname, DateTime birthDate, int departmentId);
        void Update(int id, string firstname, string lastname, DateTime birthDate, int departmentId);
        void Delete(int id);
    }
}
