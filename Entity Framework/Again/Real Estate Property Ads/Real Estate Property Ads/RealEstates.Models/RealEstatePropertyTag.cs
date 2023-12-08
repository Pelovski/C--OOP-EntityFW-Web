using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class RealEstatePropertyTag
    {
        [Key]
        public int RealEstatePropertyId { get; set; }

        public virtual RealEstateProperty RealEstateProperty { get; set; }

        [Key]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
