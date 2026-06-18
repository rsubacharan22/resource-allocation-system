using Microsoft.EntityFrameworkCore;

public class DashboardService : IDashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardDto> GetDashboard()
    {
        return new DashboardDto
        {
            TotalEmployees =
                await _context.Employees.CountAsync(),

            TotalDepartments =
                await _context.Departments.CountAsync(),

            TotalClients =
                await _context.Clients.CountAsync(),

            TotalProjects =
                await _context.Projects.CountAsync(),

            TotalResourceDemands =
                await _context.ResourceDemands.CountAsync(),

            TotalAllocations =
                await _context.Allocations.CountAsync()
        };
    }
}