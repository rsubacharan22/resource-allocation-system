public interface IResourceDemandRepository
{
    Task<List<ResourceDemand>> GetAllResourceDemands();
    Task AddResourceDemand(ResourceDemand resourceDemand);
}