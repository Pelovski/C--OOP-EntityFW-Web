using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
