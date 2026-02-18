using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs.ProjectDTOs
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
