using TaskManagementSystem.Models;

public interface ITeamService
{
    Task<Team> CreateTeamAsync(Team team);
    Task<IEnumerable<Team>> GetTeamsAsync();
    Task<TeamMembership> AddTeamMemberAsync(int teamId, TeamMembership teamMembership);
}
