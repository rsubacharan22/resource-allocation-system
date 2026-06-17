public interface IProjectRepository
{
    Task<List<Project>> GetAllProjects();

    Task AddProject(Project project);
}