using P03_FootballBetting.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var context = new FootballBettingContext();

        context.Database.EnsureCreated();
    }
}