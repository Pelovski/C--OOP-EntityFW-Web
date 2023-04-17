using System.Reflection;

using P01._Command_Pattern.Core.Contracts;

namespace P01._Command_Pattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] commandTokens = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = commandTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
