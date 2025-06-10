namespace WebApplication1.DTOs;

public class PlayerRequestDTO
{
    public PlayerDto Players { get; set; }
    public List<MatchDto> Matches { get; set; }
}