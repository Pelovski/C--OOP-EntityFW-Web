using System.Text.Json;
using RealEstates.Data;
using RealEstates.Importer;
using RealEstates.Services;

internal class Program
{
    private static void Main(string[] args)
    {
       var json = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");

        var properties = JsonSerializer.Deserialize<IEnumerable<JsonRealEstateProperty>>(json);

        var db = new RealEstateDbContext();

        IPropertyService propertyService = new PropertyService(db);

        foreach (var property in properties.Where(x => x.Price > 1000))
        {
            propertyService.Create(
                property.Size,
                property.District,
                property.Type, 
                property.BuildingType,
                property.Year,
                property.Price,
                property.Floor,
                property.TotalFloors);
        }
    }
}   