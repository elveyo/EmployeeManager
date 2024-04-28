using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Entities
{
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

    }
}
