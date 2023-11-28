namespace RealEstates.Models
{
    public class RealEstatePropertyTag
    {
        public int RealEstatePropertyId { get; set; }

        public RealEstateProperty RealEstateProperty { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
