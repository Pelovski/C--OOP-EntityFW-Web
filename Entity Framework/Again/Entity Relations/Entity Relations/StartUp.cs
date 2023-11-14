using P01_StudentSystem.Data;

internal class StartUp
{
    public static void Main(string[] args)
    {
        var context = new StudentSystemContext();
        context.Database.EnsureCreated();
    }
}