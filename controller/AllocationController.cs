using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EnterprisePlatform.Services.Interfaces;


[ApiController]
[Route("api/[controller]")]
public class AllocationController : ControllerBase
{
    private readonly IAllocationService _service;

    public AllocationController(IAllocationService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<IActionResult> GetAllAllocations()
    {
        var allocations = await _service.GetAllAllocations();

        return Ok(allocations);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAllocation(CreateAllocationDto allocationDto)
    {
        await _service.AddAllocation(allocationDto);

        return Ok();
    }
}