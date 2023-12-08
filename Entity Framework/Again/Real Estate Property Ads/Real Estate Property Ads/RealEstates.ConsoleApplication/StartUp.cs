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

      propertyService.Create(120, "Дианабад", "4-СТАЕН", "ЕПК", 2018, 200000, 16, 20);

    }
}