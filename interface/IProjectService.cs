public interface IProjectService
{
    Task<List<ProjectDto>>GetAllProjects();

    Task AddProject(CreateProjectDto projectDto);
}