using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

public class TaskManagementContext : DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options) { }

    public DbSet<TeamMembership> TeamMemberships { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserTasks)
            .WithOne(t => t.AssignedEmployee)
            .HasForeignKey(t => t.AssignedEmployeeId);

        modelBuilder.Entity<UserTask>()
            .HasMany(t => t.Attachments)
            .WithOne(a => a.UserTask)
            .HasForeignKey(a => a.TaskId);

        modelBuilder.Entity<UserTask>()
            .HasMany(t => t.Notes)
            .WithOne(n => n.UserTask)
            .HasForeignKey(n => n.TaskId);
        
        modelBuilder.Entity<UserTask>()
            .HasOne(t => t.AssignedEmployee)
            .WithMany(u => u.UserTasks)
            .HasForeignKey(t => t.AssignedEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

