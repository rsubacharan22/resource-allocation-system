public interface IDepartmentService
{
    Task<List<DepartmentDto>> GetAllDepartments();

    Task AddDepartment(CreateDepartmentDto departmentDto);
}