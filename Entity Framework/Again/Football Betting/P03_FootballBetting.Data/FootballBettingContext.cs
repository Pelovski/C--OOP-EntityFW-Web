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
            base.OnModelCreating(modelBuilder); 
        }
    }
}
