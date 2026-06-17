public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployees();

    Task AddEmployee(CreateEmployeeDto employeeDto);
}