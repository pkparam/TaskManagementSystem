namespace TaskManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }  // e.g., Member, TeamLeader

        public ICollection<UserTask>? AssignedTasks { get; set; }
        public ICollection<TeamMembership>? Teams { get; set; }
    }

}
