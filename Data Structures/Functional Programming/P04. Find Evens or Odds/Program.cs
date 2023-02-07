using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
         Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .Where(x => x % 2 == 0)
            .ToList().ForEach(x => Console.WriteLine(x));

    }
}