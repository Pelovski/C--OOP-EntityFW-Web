using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.Positions = new HashSet<Position>();
            this.Games = new HashSet<Game>();
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte SquadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
