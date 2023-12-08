using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertyService
    {
        void Create(int size, string district, string propertyType, string buildingType, int year, int price, int? floor, int? maxFloors);

        void UpdateTags(int propertyId);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);

    }
}
