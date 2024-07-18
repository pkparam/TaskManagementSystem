using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("team-performance")]
        public async Task<ActionResult<IEnumerable<TeamPerformanceReport>>> GetTeamPerformanceReport(DateTime startDate, DateTime endDate)
        {
            var report = await _reportService.GetTeamPerformanceReportAsync(startDate, endDate);
            return Ok(report);
        }
    }

}
