using EnterprisePlatform.Services.Interfaces;
namespace EnterprisePlatform.Services.Implementations
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;

        public AllocationService(IAllocationRepository allocationRepository)
        {
            _allocationRepository = allocationRepository;
        }

        public async Task<List<AllocationDto>> GetAllAllocations()
        {
            var allocations = await _allocationRepository.GetAllAllocations();

            return allocations.Select(allocation => new AllocationDto
            {
                Id = allocation.Id,
                EmployeeId = allocation.EmployeeId,
                ResourceDemandId = allocation.ResourceDemandId,
                AllocationDate = allocation.AllocationDate
            }).ToList();
        }

        public async Task AddAllocation(CreateAllocationDto createAllocationDto)
        {
            var allocation = new Allocation
            {
                EmployeeId = createAllocationDto.EmployeeId,
                ResourceDemandId = createAllocationDto.ResourceDemandId,
                AllocationDate = System.DateTime.UtcNow
            };

            var exists =
    (await _allocationRepository.GetAllAllocations())
    .Any(x =>
        x.EmployeeId == createAllocationDto.EmployeeId &&
        x.ResourceDemandId ==
            createAllocationDto.ResourceDemandId);

if (exists)
{
    throw new Exception(
        "Employee already allocated to this demand");
}

            await _allocationRepository.AddAllocation(allocation);
        }
    }
}