using P01_HospitalDatabase.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var DbContext = new HospitalContext();

        DbContext.Database.EnsureCreated();
    }
}