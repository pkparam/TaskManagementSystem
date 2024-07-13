using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TaskManagementContext _context;

    public TasksController(TaskManagementContext context)
    {
        _context = context;
    }

    // GET: api/Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserTask>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // GET: api/Tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserTask>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }

    // POST: api/Tasks
    [HttpPost]
    public async Task<ActionResult<UserTask>> PostTask(UserTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
    }

    // PUT: api/Tasks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, UserTask task)
    {
        if (id != task.TaskId)
        {
            return BadRequest();
        }
        _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    // DELETE: api/Tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("leader/{leaderId}/team-tasks")]
    public async Task<ActionResult<IEnumerable<UserTask>>> GetTeamTasks(int leaderId)
    {
        var team = await _context.Teams
            .Include(t => t.Members).ThenInclude(tm => tm.User).ThenInclude(u => u.AssignedTasks)
            .FirstOrDefaultAsync(t => t.LeaderId == leaderId);

        if (team == null)
        {
            return NotFound();
        }

        var tasks = team.Members
            .SelectMany(tm => tm.User.AssignedTasks)
            .ToList();

        return Ok(tasks);
    }

    private bool TaskExists(int id)
    {
        return _context.Tasks.Any(e => e.TaskId == id);
    }
}
