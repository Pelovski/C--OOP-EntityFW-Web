using P01._Import_the_SoftUni_Database.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var dbContext = new SoftUniContext();

        foreach (var db in dbContext.Addresses)
        {
            Console.WriteLine(db.AddressText.ToString());
        }
    }
}