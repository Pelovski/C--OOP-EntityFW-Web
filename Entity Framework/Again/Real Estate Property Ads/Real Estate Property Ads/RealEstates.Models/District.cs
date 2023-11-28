using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace RealEstates.Models
{
    public class District
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
