namespace TaskManagementSystem.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public UserTask? UserTask { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
