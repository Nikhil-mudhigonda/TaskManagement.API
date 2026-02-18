using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.TaskDTOs
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string AssignedToUserId { get; set; }
    }
}
