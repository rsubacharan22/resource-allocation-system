public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

   public async Task<List<ProjectDto>> GetAllProjects()
{
    var projects =
        await _projectRepository.GetAllProjects();

  return projects.Select(p => new ProjectDto
{
    Id = p.Id,
    Name = p.Name,
    Description = p.Description,
    StartDate = p.StartDate,
    EndDate = p.EndDate,
    ClientId = p.ClientId,
    DepartmentId = p.DepartmentId
}).ToList();
}

    public async Task AddProject(CreateProjectDto projectDto)
{
    var project = new Project
    {
        Name = projectDto.Name,
        Description = projectDto.Description,
        StartDate = projectDto.StartDate,
        EndDate = projectDto.EndDate,
        ClientId = projectDto.ClientId,
        DepartmentId = projectDto.DepartmentId
    };

    await _projectRepository.AddProject(project);
}
}