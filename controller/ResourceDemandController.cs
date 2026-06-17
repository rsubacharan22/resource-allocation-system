using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class ResourceDemandController : ControllerBase
{
    private readonly IResourceDemandService _service;

    public ResourceDemandController(IResourceDemandService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<IActionResult> GetAllResourceDemands()
    {
        var resourceDemands = await _service.GetAllResourceDemands();

        return Ok(resourceDemands);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddResourceDemand(CreateResourceDemandDto resourceDemandDto)
    {
        await _service.AddResourceDemand(resourceDemandDto);

        return Ok();
    }
}