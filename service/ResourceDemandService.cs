public class ResourceDemandService :IResourceDemandService
{
    private readonly IResourceDemandRepository _repository;

    public ResourceDemandService(IResourceDemandRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResourceDemandDto>> GetAllResourceDemands()
    {
        var resourceDemands = await _repository.GetAllResourceDemands();

        return resourceDemands.Select(rd => new ResourceDemandDto
        {
            Id = rd.Id,
            ProjectId = rd.ProjectId,
            Role = rd.Role,
            RequiredCount = rd.RequiredCount,
            StartDate = rd.StartDate,
            EndDate = rd.EndDate

        }).ToList();

    }

    public async Task AddResourceDemand(CreateResourceDemandDto createResourceDemandDto)
    {
        var resourceDemand = new ResourceDemand
        {
            ProjectId = createResourceDemandDto.ProjectId,
            Role = createResourceDemandDto.Role ?? throw new ArgumentNullException(nameof(createResourceDemandDto.Role)),
            RequiredCount = createResourceDemandDto.RequiredCount,
            StartDate = createResourceDemandDto.StartDate,
            EndDate = createResourceDemandDto.EndDate
        };

        await _repository.AddResourceDemand(resourceDemand);
    }
}