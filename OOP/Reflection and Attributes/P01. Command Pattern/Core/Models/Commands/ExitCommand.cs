using P01._Command_Pattern.Core.Contracts;

namespace P01._Command_Pattern.Core.Models.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
