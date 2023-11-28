namespace RealEstates.Models
{
    public class PropertyType
    {
        public PropertyType()
        {
            this.RealEstateProperties = new HashSet<RealEstatePropertyTag>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RealEstatePropertyTag> RealEstateProperties { get; set; }

    }
}
