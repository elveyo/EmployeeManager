namespace EmployeeManager.BusinessLogic.Entities;

public class Department
{
    public Department(string name,string code, string description)
    {
        Name = name;
        Code = code;
        Description = description;
        

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public ICollection<Employee> Employees { get;}
}