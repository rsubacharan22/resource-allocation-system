namespace EnterprisePlatform.Services.Interfaces
{
    public interface IAllocationService
    {
        Task<List<AllocationDto>> GetAllAllocations();

        Task AddAllocation(CreateAllocationDto createAllocationDto);
    }
}