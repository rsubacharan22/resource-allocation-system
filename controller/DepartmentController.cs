using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;

    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _service.GetAllDepartments();

        return Ok(departments);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddEmployee(CreateDepartmentDto DepartmentDto)
    {
        await _service.AddDepartment(DepartmentDto);

        return Ok();
    }
}