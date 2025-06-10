using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Map
{
   [Key]
   public int MapId { get; set; } 
   public string Name { get; set; }
   public string Type { get; set; }
}

