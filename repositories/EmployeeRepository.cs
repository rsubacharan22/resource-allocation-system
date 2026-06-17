using Microsoft.EntityFrameworkCore;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

   public async Task<List<Employee>> GetAllEmployees()
{
    return await _context.Employees.ToListAsync();
}

    public async Task AddEmployee(Employee employee)
{
    await _context.Employees.AddAsync(employee);

    await _context.SaveChangesAsync();
}
}