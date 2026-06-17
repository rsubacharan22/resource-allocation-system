public interface IResourceDemandService
{
    Task<List<ResourceDemandDto>> GetAllResourceDemands();
    Task AddResourceDemand(CreateResourceDemandDto createResourceDemandDto);
}