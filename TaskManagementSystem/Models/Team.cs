namespace TaskManagementSystem.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public int LeaderId { get; set; }  // UserId of the team leader

        public User? Leader { get; set; }
        public ICollection<TeamMembership>? Members { get; set; }
    }


}
