using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        public  int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        [Required]
        public byte HomeTeamGoals { get; set; }

        [Required]
        public byte AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public double HomeTeamBetRate { get; set; }

        [Required]
        public double AwayTeamBetRate { get; set; }

        [Required]
        public double DrawBetRate { get; set; }

        [Required]
        public string Result { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
