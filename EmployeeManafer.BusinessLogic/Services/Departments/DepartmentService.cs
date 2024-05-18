using Azure.Core;
using EmployeeManager.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private ApplicationDBContext _dbContext;

       public DepartmentService(ApplicationDBContext dbcontext) {
            _dbContext = dbcontext;
        }
        public void Create(string name, string code, string description)
        {
            var department = new Department()
            {
                Name = name,
                Code = code,
                Description = description
            };
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department is null) return;
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();

        }

        public Department? GetById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public void Update(int id, string name, string code, string description)
        {

            var department = GetById(id);
            if (department is null) return;
            department.Name = name;
            department.Code = code;
            department.Description = description;

            _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();
        }
    }
}
