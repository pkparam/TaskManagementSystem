using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly TaskManagementContext _context;

    public NotesController(TaskManagementContext context)
    {
        _context = context;
    }

    // POST: api/Tasks/5/Notes
    [HttpPost("/api/Tasks/{taskId}/Notes")]
    public async Task<ActionResult<Note>> PostNote(int taskId, Note note)
    {
        note.TaskId = taskId;
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetNote", new { id = note.NoteId }, note);
    }

    // Other endpoints for notes (GET, PUT, DELETE) can be added similarly.
}
