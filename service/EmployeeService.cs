public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

   public async Task<List<EmployeeDto>> GetAllEmployees()
{
    var employees =
        await _employeeRepository.GetAllEmployees();

    return employees.Select(e => new EmployeeDto
    {
        Id = e.Id,
        Name = e.Name
    }).ToList();
}

    public async Task AddEmployee(CreateEmployeeDto employeeDto)
{
    var employee = new Employee
    {
        Name = employeeDto.Name,
        Email = employeeDto.Email
    };

    await _employeeRepository.AddEmployee(employee);
}
}