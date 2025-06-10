namespace WebApplication1.DTOs;

public class PlayerTournamentDto
{
    public int PlayerId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MatchDto> Matches { get; set; }
    
}