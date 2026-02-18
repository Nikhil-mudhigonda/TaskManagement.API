using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs.TaskDTOs;
using TaskManagement.API.Models;

namespace TaskManagement.API.Services
{
    public class TaskService  : ITaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.project)
                .Include(x => x.AssignedToUserId)
                .Select(x => new TaskDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    projectName = x.project.Name,
                    AssignedToUserEmail = x.AssignedToUsers.Email,
                    TaskStatus = x.Status,
                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();
        }

        public async Task CreateTaskAsync(CreateTaskDto dto)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == dto.ProjectId && x.isActive);
            if(project == null)
            {
                throw new Exception("Project not found or inactive.");
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == dto.AssignedToUserId);
            if(user == null)
            {
                throw new Exception("Assigned user not found.");
            }
            var task = new TaskItems
            {
                Title = dto.Title,
                Description = dto.Description,
                ProjectId = dto.ProjectId,
                AssignedToUserId = dto.AssignedToUserId,
                Status = Models.TaskStatus.Pending,
                CreatedDate = DateTime.UtcNow
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTaskAsync(int id, UpdateTaskStatusDto dto, string userid)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if(task == null)
            {
                return false;
            }
            if(task.AssignedToUserId != userid)
            {
                throw new Exception("You are not allowed to Update this task");
            }
            task.Status = dto.Status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
