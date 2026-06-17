
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _DepartmentRepository;

    public DepartmentService(IDepartmentRepository DepartmentRepository)
    {
        _DepartmentRepository = DepartmentRepository;
    }

    public async Task<List<DepartmentDto>> GetAllDepartments()
    {
        var departments =
            await _DepartmentRepository.GetAllDepartments();

         return departments.Select(e=> new DepartmentDto 
         {
            Id = e.Id,
            Name = e.Name,
            DeptCode = e.DeptCode,
            DeptHead = e.DeptHead,
            Description = e.Description,

        }).ToList();
    }

    public async Task AddDepartment(CreateDepartmentDto DepartmentDto)
    {
        var department = new Department
        {
            Name = DepartmentDto.Name,
            Description = DepartmentDto.Description,
            DeptCode = DepartmentDto.DeptCode,
            DeptHead = DepartmentDto.DeptHead
        };

        await _DepartmentRepository.AddDepartment(department);
    }
}