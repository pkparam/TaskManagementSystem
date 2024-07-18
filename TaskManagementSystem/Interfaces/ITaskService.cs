using TaskManagementSystem.Models;

public interface ITaskService
{
    Task<IEnumerable<UserTask>> GetAllTasksAsync();
    Task<UserTask> GetTaskByIdAsync(int id);
    Task<UserTask> CreateTaskAsync(UserTask task);
    Task UpdateTaskAsync(int id, UserTask task);
    Task DeleteTaskAsync(int id);
}

