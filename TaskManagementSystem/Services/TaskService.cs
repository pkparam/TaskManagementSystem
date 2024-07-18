using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

public class TaskService : ITaskService
{
    private readonly TaskManagementContext _context;

    public TaskService(TaskManagementContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
    {
        return await _context.UserTasks
            .Include(t => t.AssignedEmployee)
            .Include(t => t.Manager)
            .Include(t => t.Attachments)
            .Include(t => t.Notes)
            .ToListAsync();
    }

    public async Task<UserTask> GetTaskByIdAsync(int id)
    {
        return await _context.UserTasks
            .Include(t => t.AssignedEmployee)
            .Include(t => t.Manager)
            .Include(t => t.Attachments)
            .Include(t => t.Notes)
            .FirstOrDefaultAsync(t => t.TaskId == id);
    }

    public async Task<UserTask> CreateTaskAsync(UserTask task)
    {
        _context.UserTasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task UpdateTaskAsync(int id, UserTask task)
    {
        if (id != task.TaskId)
        {
            throw new ArgumentException("Task ID mismatch");
        }

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _context.UserTasks.FindAsync(id);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        _context.UserTasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
