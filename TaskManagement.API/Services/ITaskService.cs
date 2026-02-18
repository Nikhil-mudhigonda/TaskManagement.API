using TaskManagement.API.DTOs.TaskDTOs;

namespace TaskManagement.API.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<bool> UpdateTaskAsync(int id, UpdateTaskStatusDto updateTaskStatusDto, string userid);
    }
}
