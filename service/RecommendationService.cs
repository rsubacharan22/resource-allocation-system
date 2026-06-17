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
        var recommendations =
            await _context.Utilizations
                .Include(u => u.Employee)
                .OrderBy(u => u.AllocationPercentage)
                .Select(u => new RecommendationDto
                {
                    EmployeeId = u.Employee.Id,
                    EmployeeName = u.Employee.Name,
                    Email = u.Employee.Email,
                    UtilizationPercentage =
                        u.AllocationPercentage,
                    RecommendationReason =
                        "Lowest utilization"
                })
                .ToListAsync();

        return recommendations;
    }
}