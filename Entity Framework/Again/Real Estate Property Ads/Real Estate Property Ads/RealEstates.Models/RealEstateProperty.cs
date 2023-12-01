using System;
using System.Reflection.Metadata.Ecma335;

namespace RealEstates.Models
{
    public class RealEstateProperty
    {

        public RealEstateProperty()
        {
                this.Tags = new HashSet<RealEstatePropertyTag>();
        }
        public int Id { get; set; }


        public int Size { get; set; }

        public int? Floor { get; set; }

        public int TotalNumberOfFloors { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int? Year { get; set; }

        public int PropertyTypeId { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get;}

        public int Price { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
