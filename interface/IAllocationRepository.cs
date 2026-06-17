public interface IAllocationRepository
{
    Task<List<Allocation>> GetAllAllocations();
    Task AddAllocation(Allocation allocation);
}