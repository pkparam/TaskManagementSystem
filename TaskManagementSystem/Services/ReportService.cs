using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public class ReportService : IReportService
    {
        private readonly TaskManagementContext _context;

        public ReportService(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamPerformanceReport>> GetTeamPerformanceReportAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _context.UserTasks
                .Where(t => t.DueDate >= startDate && t.DueDate <= endDate)
                .GroupBy(t => t.AssignedEmployee.Role) // Assuming TeamName is derived from User's Role
                .Select(g => new TeamPerformanceReport
                {
                    TeamName = g.Key,
                    TotalTasks = g.Count(),
                    CompletedTasks = g.Count(t => t.Status == "Completed"),
                    PendingTasks = g.Count(t => t.Status != "Completed")
                })
                .ToListAsync();

            return reports;
        }
    }

}
