using Football_Team_Generator.Core;
using Football_Team_Generator.Models;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var engine = new Engine();

        engine.Run();
    }
}