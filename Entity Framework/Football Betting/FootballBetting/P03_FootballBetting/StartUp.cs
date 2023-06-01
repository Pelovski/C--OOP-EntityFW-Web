using P03_FootballBetting.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var dbContext = new FootballBettingContext();

        dbContext.Database.EnsureCreated();
    }
}