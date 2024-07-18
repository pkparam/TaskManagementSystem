namespace TaskManagementSystem.Models
{
    public class TeamPerformanceReport
    {
        public string TeamName { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
    }

}
