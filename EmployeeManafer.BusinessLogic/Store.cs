using EmployeeManager.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic
{
    public static class Store
    {
        public static int EmployeeID = 1;
        public static List<Employee> EmployeeStore = [

            new Employee()
            {
                Id = EmployeeID,
                FirstName = "Elvir",
                LastName = "Agic",
                BirthDate = new DateTime(2003,9,11),
                DepartmentId = 1

            }
            ];

        public static List<Department> DepartmentStore =
        [

            new Department("Development Department", 1, "Department for software development"),
            new Department("Quality Assurance Department", 2, "Department for software quality"),
            new Department("Sales and Marketing Department", 3, "Department for software promotion")

        ];

        public static List<Position> PositionStore =
        [
            new Position("UI/UX Designer", 1, "Making project beautiful", DepartmentStore[0]),
            new Position("Database Engineer", 2, "Working with database", DepartmentStore[0]),
            new Position("Sales Representive", 3, "Searching for clients and selling the product", DepartmentStore[2]),
            new Position("Software Test Engineer", 4, "Testing the code", DepartmentStore[1]),





        ];

    }
}
