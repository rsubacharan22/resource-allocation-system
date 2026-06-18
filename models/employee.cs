public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Skill { get; set; } = string.Empty;

    public Department Department { get; set; } = null!;
}