using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly IRecommendationService _service;

    public RecommendationController(
        IRecommendationService service)
    {
        _service = service;
    }

    [HttpGet("{resourceDemandId}")]
    public async Task<IActionResult>
        GetRecommendations(int resourceDemandId)
    {
        var result =
            await _service.GetRecommendations(resourceDemandId);

        return Ok(result);
    }
}