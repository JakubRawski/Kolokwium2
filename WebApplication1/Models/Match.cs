using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    [ForeignKey(nameof(Tournament))]
    public int TournamentId { get; set; }
    [ForeignKey(nameof(Map))]
    public int MapId { get; set; }
    public DateTime MatchDate  { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public decimal? BestRating { get; set; }
}