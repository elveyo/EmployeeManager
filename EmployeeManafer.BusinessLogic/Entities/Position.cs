namespace EmployeeManager.BusinessLogic.Entities;

public class Position
{
    public Position(string name,int code, string description, Department department)
    {
        Name = name;
        Code = code;
        Description = description;
        Department = department;

    }
    public string Name { get; set; }
    public int Code { get; set; }
    public string Description { get; set; }
    public Department Department { get; set; }
}