using Microsoft.EntityFrameworkCore;

public class AllocationRepository : IAllocationRepository
{
    private readonly AppDbContext _dbContext = null!;

    public AllocationRepository(AppDbContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Allocation>> GetAllAllocations()
    {
        return await _dbContext.Allocations.ToListAsync();
    }

    public async Task AddAllocation(Allocation allocation)
    {
        await _dbContext.Allocations.AddAsync(allocation);

        await _dbContext.SaveChangesAsync();
    }
}
