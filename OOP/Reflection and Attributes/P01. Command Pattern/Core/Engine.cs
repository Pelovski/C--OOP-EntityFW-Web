namespace P01._Command_Pattern.Core
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
            while (true)
            {
                string args = Console.ReadLine();

                try
                {
                    string result = this
                        .commandInterpreter.Read(args);

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
