namespace TaskManagementSystem.Models
{
    public class TeamMembership
    {
        public int TeamMembershipId { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public Team? Team { get; set; }
        public User? User { get; set; }
    }

}