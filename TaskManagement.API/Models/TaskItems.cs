namespace TaskManagement.API.Models
{
    public class TaskItems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project project { get; set; }
        public string AssignedToUserId { get; set; }
        public ApplicationUsers AssignedToUsers { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
