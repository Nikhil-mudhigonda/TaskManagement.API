using TaskManagement.API.DTOs.ProjectDTOs;

namespace TaskManagement.API.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetProjectsAsync();
        Task<ProjectDTO?> GetProjectByIdAsync(int id);
        Task CreateProject(CreateProjectDto createProjectDto);

        Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto);
        Task<bool> DeactivateProjectAsync(int id);
    }
}
