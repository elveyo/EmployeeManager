namespace EmployeeManager.BusinessLogic.Entities;

public class Department
{
    public Department(string name,int code, string description)
    {
        Id = code;
        Name = name;
        Code = code;
        Description = description;
        

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Code { get; set; }
    public string Description { get; set; }
}