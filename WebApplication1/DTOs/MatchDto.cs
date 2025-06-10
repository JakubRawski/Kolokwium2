namespace WebApplication1.DTOs;

public class MatchDto
{
    public int MatchId { get; set; }
    public TournamentDto TournamentId { get; set; } = null!;
    public MapDto MapId { get; set; } = null!;
    public DateTime MatchDate  { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public decimal? Tournament { get; set; }
}