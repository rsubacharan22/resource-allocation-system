using Microsoft.EntityFrameworkCore;

public class RecommendationService : IRecommendationService
{
    private readonly AppDbContext _context;

    public RecommendationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RecommendationDto>>
    GetRecommendations(int resourceDemandId)
{
    var demand = await _context.ResourceDemands
        .FirstOrDefaultAsync(x => x.Id == resourceDemandId);

    if (demand == null)
    {
        throw new Exception("Resource Demand not found");
    }

    var recommendations =
        await _context.Utilizations
            .Include(u => u.Employee)
            .Where(u =>
                u.Employee.Skill == demand.Role)
            .OrderBy(u => u.AllocationPercentage)
            .Select(u => new RecommendationDto
            {
                EmployeeId = u.Employee.Id,
                EmployeeName = u.Employee.Name,
                Email = u.Employee.Email,
                Skill = u.Employee.Skill,
                UtilizationPercentage =
                    u.AllocationPercentage,
                RecommendationReason =
                    "Skill matched and lowest utilization"
            })
            .ToListAsync();

    return recommendations;
}
}