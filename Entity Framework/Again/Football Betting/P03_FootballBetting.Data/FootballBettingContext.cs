using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public FootballBettingContext()
        {
        }


        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Arsenal;Database=FootballBetting;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new {ps.PlayerId, ps.GameId });

            modelBuilder.Entity<Color>()
                 .HasMany(c => c.PrimaryKitTeams)
                 .WithOne(t => t.PrimaryKitColor)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Color>()
               .HasMany(c => c.SecondaryKitTeams)
               .WithOne(t => t.SecondaryKitColor)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                 .HasMany(g => g.PlayerStatistics)
                 .WithOne(ps => ps.Game)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                 .HasMany(g => g.Bets)
                 .WithOne(b => b.Game)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.PlayerStatistics)
                .WithOne(ps => ps.Player)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Position>()
            .HasMany(po => po.Players)
            .WithOne(p => p.Position)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Towns)
                .WithOne(t => t.Country)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
              .HasMany(t => t.HomeGames)
              .WithOne(g => g.HomeTeam)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
              .HasMany(t => t.AwayGames)
              .WithOne(g => g.AwayTeam)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
              .HasMany(t => t.Players)
              .WithOne(p => p.Team)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Town>()
              .HasMany(to => to.Teams)
              .WithOne(t => t.Town)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Bets)
             .WithOne(b => b.User)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
