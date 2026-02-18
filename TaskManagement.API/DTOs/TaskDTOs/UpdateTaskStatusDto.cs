using System.ComponentModel.DataAnnotations;
using TaskStatus = TaskManagement.API.Models.TaskStatus;

namespace TaskManagement.API.DTOs.TaskDTOs
{
    public class UpdateTaskStatusDto
    {
        [Required]
        public TaskStatus Status { get; set; }
    }
}
