using P01._Command_Pattern.Core.Contracts;

namespace P01._Command_Pattern.Core.Models.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
