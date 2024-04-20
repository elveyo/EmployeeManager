using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Entities
{

    public class EmployeeIndexVM
    {

        public List<EmployeeView>Employees { get; set; } 
        
    }

    public class EmployeeView
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }

    }
}
