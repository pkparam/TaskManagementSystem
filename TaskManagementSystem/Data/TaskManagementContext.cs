using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

public class TaskManagementContext : DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options) { }

    // Parameterless constructor for design-time services
    public TaskManagementContext() { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserTask> Tasks { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<TeamMembership> TeamMemberships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserTask>()
            .HasKey(ut => ut.TaskId);

        modelBuilder.Entity<Team>()
            .HasKey(t => t.TeamId);

        modelBuilder.Entity<TeamMembership>()
            .HasKey(tm => tm.TeamMembershipId);

        modelBuilder.Entity<TeamMembership>()
            .HasOne(tm => tm.Team)
            .WithMany(t => t.Members)
            .HasForeignKey(tm => tm.TeamId);

        modelBuilder.Entity<TeamMembership>()
            .HasOne(tm => tm.User)
            .WithMany(u => u.Teams)
            .HasForeignKey(tm => tm.UserId);

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.AssignedUser)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(ut => ut.AssignedTo);
    }
}
