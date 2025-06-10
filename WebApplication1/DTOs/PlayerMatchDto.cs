namespace WebApplication1.DTOs;

public class PlayerMatchDto
{
    public MatchDto MatchId { get; set; }
    public PlayerDto PlayerId { get; set; }
    public int MVPs  { get; set; }
    public decimal Rating { get; set; }
}