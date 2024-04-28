using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Entities
{
    public class ProjectEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project  { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
    }
}
