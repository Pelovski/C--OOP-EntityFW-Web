using P03_SalesDatabase.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var salesContext = new SalesContext();

        salesContext.Database.EnsureCreated();
    }
}