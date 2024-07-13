namespace TaskManagementSystem.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; } // UserId of the note creator
        public DateTime CreatedDate { get; set; }
    }

}
