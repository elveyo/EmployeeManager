using EmployeeManager.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic
{
    public class ApplicationDBContext : DbContext
    {

       public  ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }

    }
}
