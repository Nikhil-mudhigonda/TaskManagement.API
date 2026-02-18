using Microsoft.SqlServer.Server;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool isActive { get; set; } = true;
    }
}
