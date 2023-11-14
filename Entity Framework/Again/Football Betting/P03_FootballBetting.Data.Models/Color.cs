using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();

        }

        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public  ICollection<Team> PrimaryKitTeams { get; set; }
        public ICollection<Team> SecondaryKitTeams { get; set; }

    }
}
