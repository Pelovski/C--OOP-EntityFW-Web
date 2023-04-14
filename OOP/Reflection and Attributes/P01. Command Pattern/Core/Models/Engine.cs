namespace P01._Command_Pattern.Core.Models
{
    using P01._Command_Pattern.Core.Contracts;
    internal class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {

        }
    }
}
