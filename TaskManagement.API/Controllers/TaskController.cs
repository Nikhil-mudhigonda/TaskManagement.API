using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.API.DTOs.TaskDTOs;
using TaskManagement.API.Services;

namespace TaskManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService task)
        {
            _taskService = task;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> CreateTask(CreateTaskDto task)
        {
            await _taskService.CreateTaskAsync(task);
            return Ok();
        }

        [Authorize(Roles = "Employee")]
        [HttpPut("{id}/status")]
        public async Task<ActionResult> UpdateStatus(int id, UpdateTaskStatusDto statusDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updated = await _taskService.UpdateTaskAsync(id, statusDto, userId);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        } 
    }
}
