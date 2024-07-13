using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class AttachmentsController : ControllerBase
{
    private readonly TaskManagementContext _context;

    public AttachmentsController(TaskManagementContext context)
    {
        _context = context;
    }

    // POST: api/Tasks/5/Attachments
    [HttpPost("/api/Tasks/{taskId}/Attachments")]
    public async Task<ActionResult<Attachment>> PostAttachment(int taskId, [FromForm] IFormFile file)
    {
        var attachment = new Attachment
        {
            TaskId = taskId,
            FilePath = await SaveFileAsync(file),
            UploadedBy = 1 /* Current User ID */,
            UploadedDate = DateTime.UtcNow
        };
        _context.Attachments.Add(attachment);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAttachment", new { id = attachment.AttachmentId }, attachment);
    }

    private async Task<string> SaveFileAsync(IFormFile file)
    {
        var filePath = Path.Combine("Uploads", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}