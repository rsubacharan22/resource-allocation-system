using Microsoft.EntityFrameworkCore;

public class UtilizationRepository : IUtilizationRepository
{
    private readonly AppDbContext _context;

    public UtilizationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Utilization>> GetAllUtilizations()
    {
        return await _context.Utilizations.ToListAsync();
    }

    public async Task AddUtilization(Utilization utilization)
    {
        await _context.Utilizations.AddAsync(utilization);

        await _context.SaveChangesAsync();
    }
}