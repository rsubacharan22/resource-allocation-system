using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class UtilizationController : ControllerBase
{
    private readonly IUtilizationService _service;

    public UtilizationController(IUtilizationService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<IActionResult> GetAllUtilizations()
    {
        var utilizations =
            await _service.GetAllUtilizations();

        return Ok(utilizations);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddUtilization(
        CreateUtilizationDto utilizationDto)
    {
        await _service.AddUtilization(utilizationDto);

        return Ok();
    }
}