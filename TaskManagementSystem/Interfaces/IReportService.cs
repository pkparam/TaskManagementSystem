using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<TeamPerformanceReport>> GetTeamPerformanceReportAsync(DateTime startDate, DateTime endDate);
    }

}
