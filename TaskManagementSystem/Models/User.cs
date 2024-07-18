namespace TaskManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Employee, Manager, Admin
        public ICollection<UserTask> UserTasks { get; set; }
    }

}
