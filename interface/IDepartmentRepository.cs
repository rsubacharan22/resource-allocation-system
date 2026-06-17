public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartments();

    Task AddDepartment(Department department);
}