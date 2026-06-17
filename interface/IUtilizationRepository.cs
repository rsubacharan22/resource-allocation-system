public interface IUtilizationRepository
{
    Task<List<Utilization>> GetAllUtilizations();

    Task AddUtilization(Utilization utilization);
}