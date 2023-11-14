using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
