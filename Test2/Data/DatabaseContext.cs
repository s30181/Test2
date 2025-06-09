using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Player> Players { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Player>().HasData(new List<Player>()
        {
            new Player()
            {
                PlayerId = 1,
                FirstName = "John",
                LastName = "Smith",
                BirthDate = new DateTime(2005, 05, 20),
            }
        });

        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament()
            {
                TournamentId = 1,
                Name = "CS2 Summer Cup",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7),
            }
        });

        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map()
            {
                MapId = 1,
                Name = "Inferno",
                Type = "Map type"
            },
            new Map()
            {
                MapId = 2,
                Name = "Mirage",
                Type = "Map type"
            }
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match()
            {
                MapId = 1,
                MatchId = 1,
                TournamentId = 1,
                BestRating = (decimal)1.25,
                Team1Score = 16,
                Team2Score = 12
            },
            new Match()
            {
                MatchId = 2,
                MapId = 2,
                TournamentId = 1,
                BestRating = (decimal)1.10,
                Team1Score = 10,
                Team2Score = 16
            }
        });

        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch()
            {
                PlayerId = 1,
                MatchId = 1,
                MVPs = 3,
                Rating = (decimal)1.25
            },
            new PlayerMatch()
            {
                PlayerId = 1,
                MatchId = 2,
                MVPs = 2,
                Rating = (decimal)1.10
            }
        });
    }
}