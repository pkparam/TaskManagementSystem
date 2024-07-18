namespace TaskManagementSystem.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int TaskId { get; set; }
        public string FilePath { get; set; }
        public UserTask? UserTask { get; set; }
        public int UploadedBy { get; set; } // UserId of the uploader
        public DateTime UploadedDate { get; set; }
    }

}
