using Microsoft.EntityFrameworkCore;

public class ResourceDemandRepository : IResourceDemandRepository
{
    private readonly AppDbContext _dbContext = null!;

    public ResourceDemandRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<ResourceDemand>> GetAllResourceDemands()
    {
        return await _dbContext.Set<ResourceDemand>().ToListAsync();
    }

    public async Task AddResourceDemand(ResourceDemand resourceDemand)
    {
        await _dbContext.Set<ResourceDemand>().AddAsync(resourceDemand);
        await _dbContext.SaveChangesAsync();
    }


}