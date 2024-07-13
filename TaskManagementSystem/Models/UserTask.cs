namespace TaskManagementSystem.Models
{
    public class UserTask
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }  // Pending, In Progress, Completed
        public DateTime DueDate { get; set; }
        public int CreatedBy { get; set; }  // UserId of the creator
        public int AssignedTo { get; set; }  // UserId of the assignee
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public User? AssignedUser { get; set; }
    }


}
