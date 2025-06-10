using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Map> Maps { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<PlayerMatch> PlayerMatches { get; set; } = null!;
    public DbSet<Tournament> Tournaments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasKey(ph => new { ph.MatchId, ph.TournamentId, ph.MapId }); 

        modelBuilder.Entity<PlayerMatch>()
            .Property(wm => wm.Rating)
            .HasColumnType("decimal(4,2)");
            
        modelBuilder.Entity<PlayerMatch>()
            .HasKey(ph => new { ph.MatchId, ph.PlayerId}); 
        

        modelBuilder.Entity<Map>().HasData(
            new Map { MapId = 1, Name = "Dust_2", Type = "Tournament"},
            new Map { MapId = 2, Name = "Mirage", Type = "Normal"}
        );

        modelBuilder.Entity<Player>().HasData(
            new Player { PlayerId = 1, Firstname = "Jan", Lastname = "Kowalski",BirthDate = new DateTime(2005, 6, 3, 9, 0, 0) },
            new Player { PlayerId = 2, Firstname = "Anna", Lastname = "Nowak",BirthDate = new DateTime(2003, 6, 3, 9, 0, 0) }
            );

        modelBuilder.Entity<Tournament>().HasData(
            new Tournament { TournamentId = 1, Name = "Esports2025", StartDate = new DateTime(2025, 6, 3, 9, 0, 0), EndDate = new DateTime(2025, 7, 3, 9, 0, 0) },
            new Tournament { TournamentId = 2, Name = "Esports2024", StartDate = new DateTime(2024, 6, 3, 9, 0, 0), EndDate = new DateTime(2024, 7, 3, 9, 0, 0) }
            );

        modelBuilder.Entity<Match>().HasData(
            new Match { MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = new DateTime(2025, 6, 3, 9, 0, 0),Team1Score = 21, Team2Score = 37, BestRating = 20},
            new Match { MatchId = 2, TournamentId = 2, MapId = 2, MatchDate = new DateTime(2024, 6, 3, 9, 0, 0),Team1Score = 13, Team2Score = 37, BestRating = 30}
            );

        modelBuilder.Entity<PlayerMatch>().HasData(
            new PlayerMatch { MatchId = 1, PlayerId = 1, MVPs = 1, Rating = 69 },
            new PlayerMatch { MatchId = 2, PlayerId = 2, MVPs = 2, Rating = 31 }
            );
    }

}