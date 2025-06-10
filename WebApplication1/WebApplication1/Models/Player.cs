using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime BirthDate { get; set; }
}