using System.Linq.Expressions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class PropertyService : IPropertyService
    {
        private RealEstateDbContext db;
        public PropertyService(RealEstateDbContext db)
        {
            this.db = db;
        }
        public void Create(int size, string district, string propertyType, string buildingType, int year, int price, int? floor, int? maxFloors)
        {
            var property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year,
                Floor = floor,
                TotalNumberOfFloors = (int)maxFloors,
            };

            if (property.Year < 1800)
            {
                property.Year = null;
            }

            if (property.Floor < 0)
            {
                property.Floor = null;
            }

            if (property.TotalNumberOfFloors < 0)
            {
                property.TotalNumberOfFloors = 0;
            }

            // District Type

            var districtEntity = this.db.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim());

            if (districtEntity == null)
            {
                districtEntity = new District { Name = district };
            }

            property.District = districtEntity;


            // PropertyType

            var propertyEntity = this.db.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());

            if (propertyEntity == null)
            {
                propertyEntity = new PropertyType { Name = propertyType };
            }

            property.PropertyType = propertyEntity;

            // BuildingType Type

            var buildingTypeEntity = this.db.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());

            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType { Name = buildingType };
            }

            property.BuildingType = buildingTypeEntity;

            this.db.RealEstateProperties.Add(property);
            this.db.SaveChanges();

            this.UpdateTags(property.Id);
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return db.RealEstateProperties
               .Where(x => x.Year >= minYear && x.Price <= maxYear && x.Size >= minSize && x.Size <= maxSize)
               .Select(MapToPropertyViewModel())
               .OrderBy(x => x.Price)
               .ToList();

        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
        {
            return x => new PropertyViewModel
            {
                Price = x.Price,
                Floor = (x.Floor ?? 0) + "/" + (x.TotalNumberOfFloors ?? 0),
                Size = x.Size,
                Year = (int)x.Year,
                BuildingType = x.BuildingType.Name,
                District = x.District.Name,
                PropertyType = x.PropertyType.Name,
            };
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            return this.db.RealEstateProperties
                  .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                  .Select(MapToPropertyViewModel())
                  .OrderBy(x => x.Price)
                  .ToList();
        }

        public void UpdateTags(int propertyId)
        {
            var property = this.db.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);

            if (property == null)
            {

                return;
            }

            property.Tags.Clear();

            if (property.Year.HasValue && property.Year < 1980)
            {
                property.Tags.Add(
                    new RealEstatePropertyTag
                    { 
                        Tag = GetOrCreateTag("OldBuilding") 
                    });
            }

            if (property.Year > 2018 && property.TotalNumberOfFloors > 5)
            {
                property.Tags.Add(
                    new RealEstatePropertyTag
                    {
                        Tag = GetOrCreateTag("HasParking")
                    });
            }

            if (property.Floor == property.TotalNumberOfFloors)
            {
                property.Tags.Add(
                    new RealEstatePropertyTag
                    {
                        Tag = GetOrCreateTag("LastFloor")
                    });
            }

            if (((double)property.Price / property.Size) < 800)
            {
                property.Tags.Add(
                    new RealEstatePropertyTag
                    {
                        Tag = GetOrCreateTag("CheapProperty")
                    });
            }

            if (((double)property.Price / property.Size) > 2000)
            {
                property.Tags.Add(
                    new RealEstatePropertyTag
                    {
                        Tag = GetOrCreateTag("ExpensiveProperty")
                    });
            }

            this.db.SaveChanges();
        }

        private Tag GetOrCreateTag(string tag)
        {
           var tagEntity =  this.db.Tags.FirstOrDefault(x => x.Name.Trim() == tag.Trim());

            if (tagEntity == null)
            {
                tagEntity = new Tag { Name = tag };
            }

            return tagEntity;
        }
    }
}
