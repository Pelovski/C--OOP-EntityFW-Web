using RealEstates.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var context = new RealEstateDbContext();

        context.Database.EnsureCreated();
    }
}