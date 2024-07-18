using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

public class TeamService : ITeamService
{
    private readonly TaskManagementContext _context;

    public TeamService(TaskManagementContext context)
    {
        _context = context;
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<IEnumerable<Team>> GetTeamsAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<TeamMembership> AddTeamMemberAsync(int teamId, TeamMembership teamMembership)
    {
        var team = await _context.Teams.FindAsync(teamId);
        if (team == null)
        {
            throw new KeyNotFoundException("Team not found.");
        }

        teamMembership.TeamId = teamId;
        _context.TeamMemberships.Add(teamMembership);
        await _context.SaveChangesAsync();

        return teamMembership;
    }
}
