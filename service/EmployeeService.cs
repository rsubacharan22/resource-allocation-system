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

    return employees.Select(employee => new EmployeeDto
{
    Id = employee.Id,
    Name = employee.Name,
    Skill = employee.Skill
}).ToList();
}

    public async Task AddEmployee(CreateEmployeeDto employeeDto)
{
    var employee = new Employee
{
    Name = employeeDto.Name,
    Email = employeeDto.Email,
    DepartmentId = employeeDto.DepartmentId,
    Skill = employeeDto.Skill
};

    await _employeeRepository.AddEmployee(employee);
}
}