using EmployeeManager.BusinessLogic.Entities;
using EmployeeManager.BusinessLogic.Migrations;
using EmployeeManager.BusinessLogic.Services.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {

        private ApplicationDBContext dbContext;

        public EmployeeService(ApplicationDBContext context)
        {
            dbContext = context;
        }

        public void Create(string username, string password, string email, string firstname, string lastname, DateTime birthDate, int departmentId)
        {
            var employee = new Employee()
            {
                FirstName = firstname,
                LastName = lastname,
                BirthDate = birthDate,
                DepartmentId = departmentId,
                User = new User()
                {
                    Username = username,
                    Password = password,
                    Email = email,
                }

            };
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetElementById(id);

            if (employee is null) return;
            dbContext.Employees.Remove(employee);
            dbContext.Users.Remove(employee.User);

            dbContext.SaveChanges();
        }

        public Employee? GetElementById(int id)
        {
            return dbContext.Employees
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public void Update(int id, string firstname, string lastname, DateTime birthDate, int departmentId)
        {
            var employee = GetElementById(id);

            if (employee is null) return;

            employee.FirstName = firstname;
            employee.LastName = lastname;
            employee.BirthDate = birthDate;
            employee.DepartmentId = departmentId;


            var changedThings = dbContext
                .ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .ToList();
            dbContext.SaveChanges();

        }
    }
}
