using P03._Shopping_Spree.Core;
using P03._Shopping_Spree.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        
		try
		{
            Engine engine = new Engine();
            engine.Run();
        }
		catch (Exception e)
		{

            Console.WriteLine(e.Message);
		}
        
    }
}