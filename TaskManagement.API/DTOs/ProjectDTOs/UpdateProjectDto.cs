using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.ProjectDTOs
{
    public class UpdateProjectDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
