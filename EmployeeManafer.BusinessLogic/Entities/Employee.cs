using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Entities
{
    public class Employee
    {

        public int     Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
       public Department Department { get; set; }
        public User User { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
