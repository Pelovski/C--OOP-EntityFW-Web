using P01._Command_Pattern.Core;
using P01._Command_Pattern.Core.Contracts;
public class StartUp
{
    private static void Main(string[] args)
    {
        ICommandInterpreter command = new CommandInterpreter();
        IEngine engine = new Engine(command);
        engine.Run();
    }
}