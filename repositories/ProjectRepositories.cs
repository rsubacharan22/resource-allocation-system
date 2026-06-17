using Microsoft.EntityFrameworkCore;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task AddProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }
}