using TaskStatus = TaskManagement.API.Models.TaskStatus;

namespace TaskManagement.API.DTOs.TaskDTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string projectName { get; set; }
        public string AssignedToUserEmail { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
