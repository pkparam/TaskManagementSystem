using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public string Status { get; set; } // Pending, In Progress, Completed
        public int AssignedEmployeeId { get; set; }
        public User AssignedEmployee { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Note> Notes { get; set; }
    }



}
