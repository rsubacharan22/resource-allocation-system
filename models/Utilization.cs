public class Utilization
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int AllocationPercentage { get; set; }

    public DateTime RecordedDate { get; set; }

    public Employee Employee { get; set; } = null!;
}