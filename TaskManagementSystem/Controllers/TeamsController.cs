using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(Team team)
    {
        if (team == null)
        {
            return BadRequest();
        }

        var createdTeam = await _teamService.CreateTeamAsync(team);
        return Ok(createdTeam);
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var teams = await _teamService.GetTeamsAsync();
        return Ok(teams);
    }

    [HttpPost("{teamId}/members")]
    public async Task<IActionResult> AddTeamMember(int teamId, TeamMembership teamMembership)
    {
        try
        {
            var addedMember = await _teamService.AddTeamMemberAsync(teamId, teamMembership);
            return Ok(addedMember);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
