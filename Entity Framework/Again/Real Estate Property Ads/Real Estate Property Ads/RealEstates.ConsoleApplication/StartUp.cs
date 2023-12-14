using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var context = new RealEstateDbContext();
        context.Database.Migrate();

        IPropertyService propertyService =  new PropertyService(context);

        propertyService.Create(100, "Дианабад", "4-СТАЕН", "ЕПК", 2019, 210000, 20, 20);

        //IDistrictService districtService = new DistrictService(context);

        //var districts = districtService.GetTopDistrictsByAvaragePrice(100);

        //foreach (var district in districts)
        //{
        //    Console.WriteLine($"{district.Name} => Price: {district.AvaragePrice:f2} ({district.MinPrice}-{district.MaxPrice}) => {district.PropertiesCount} properties.");
        //}

        var properties = propertyService.SearchByPrice(10000, 22000);

        foreach (var property in properties)
        {
            Console.WriteLine(property.Year);
        }

    }
}