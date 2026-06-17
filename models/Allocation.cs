public class Allocation
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ResourceDemandId { get; set; }

    public DateTime AllocationDate { get; set; }

    public Employee Employee { get; set; } = null!;

    public ResourceDemand ResourceDemand { get; set; } = null!;
}