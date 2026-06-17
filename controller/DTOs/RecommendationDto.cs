public class RecommendationDto
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Skill { get; set; } = string.Empty;

    public int UtilizationPercentage { get; set; }

    public string RecommendationReason { get; set; } = string.Empty;
}