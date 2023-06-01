using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                .HasKey(u => u.BetId);

                entity
                .Property(b => b.Amount)
                .IsRequired();

                entity
                .Property(b => b.Prediction)
                .IsRequired();

                entity
                .Property(b => b.DateTime)
                .IsRequired();

                entity
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(u => u.UserId);

                entity
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasKey(t => t.TeamId);

                entity
                .Property(t => t.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

                entity
                .Property(t => t.Initials)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(3);

                entity
                .Property(t => t.Budget)
                .IsRequired();


                entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);


                entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(t => t.Town)
                .WithMany(tw => tw.Teams)
                .HasForeignKey(t => t.TownId);


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                .HasKey(u => u.UserId);

                entity
                .Property(u => u.Username)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

                entity
                .Property(u => u.Password)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(20);

                entity
                .Property(u => u.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(30);

                entity
                .Property(u => u.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(25);

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasKey(g => g.GameId);

                entity
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                .HasKey(tw => tw.TownId);

                entity
                .Property(tw => tw.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(30);

                entity
                .HasOne(tw => tw.Country)
                .WithMany(co => co.Towns)
                .HasForeignKey(tw => tw.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity
                .HasKey(c => c.ColorId);

                entity
                .Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                .HasKey(p => p.PlayerId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(30);

                entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Country>(entity =>
            { 
                entity
                .HasKey(c => c.CountryId);

                entity
                .Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);
            
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity
                .HasKey(p => p.PositionId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(30);

            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(ps => ps.Player)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
