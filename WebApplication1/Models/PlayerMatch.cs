using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class PlayerMatch
{
    [Key]
    [ForeignKey(nameof(MatchId))]
    public int MatchId { get; set; }
    [Key]
    [ForeignKey(nameof(MatchId))]
    public int PlayerId { get; set; }
    public int MVPs  { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public decimal Rating { get; set; }
}