using Microsoft.EntityFrameworkCore;
public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

   public async Task<List<Department>> GetAllDepartments()
{
    return await _context.Departments.ToListAsync();
}

    public async Task AddDepartment(Department department)
{
    await _context.Departments.AddAsync(department);

    await _context.SaveChangesAsync();
}
}