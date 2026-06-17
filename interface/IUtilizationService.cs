public interface IUtilizationService
{
    Task<List<UtilizationDto>> GetAllUtilizations();

    Task AddUtilization(CreateUtilizationDto createUtilizationDto);
}