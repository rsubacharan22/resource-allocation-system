public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployees();

    Task AddEmployee(Employee employee);
}