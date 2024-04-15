namespace EmployeeManager.BusinessLogic.Entities;

public class Department
{
    public Department(string name,int code, string description)
    {
        Name = name;
        Code = code;
        Description = description;

    }
    public string Name { get; set; }
    public int Code { get; set; }
    public string Description { get; set; }
}