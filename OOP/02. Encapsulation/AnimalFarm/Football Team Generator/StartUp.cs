using Football_Team_Generator.Models;

internal class StartUp
{
    private static void Main(string[] args)
    {
        int shooting = 75;
        int passing = 85;
        int dribble = 84;
        int sprint = 92;
        int endurance = 67;

        string name = "Saka";

        var stat = new Stat(endurance, sprint, dribble, passing, shooting);


        var player = new Player(name, stat);
        Console.WriteLine(player.OverallSkill);
    }
}