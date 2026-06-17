public class UtilizationService : IUtilizationService
{
    private readonly IUtilizationRepository _repository;

    public UtilizationService(IUtilizationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UtilizationDto>> GetAllUtilizations()
    {
        var utilizations =
            await _repository.GetAllUtilizations();

        return utilizations.Select(u => new UtilizationDto
        {
            Id = u.Id,
            EmployeeId = u.EmployeeId,
            AllocationPercentage = u.AllocationPercentage,
            RecordedDate = u.RecordedDate
        }).ToList();
    }

    public async Task AddUtilization(
        CreateUtilizationDto createUtilizationDto)
    {
        var utilization = new Utilization
        {
            EmployeeId = createUtilizationDto.EmployeeId,
            AllocationPercentage =
                createUtilizationDto.AllocationPercentage,
            RecordedDate = DateTime.UtcNow
        };

        await _repository.AddUtilization(utilization);
    }
}