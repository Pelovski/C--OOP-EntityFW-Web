using System;
using System.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        Action<string> action = (name) => 
        {
            Console.WriteLine($"Sir {name}");
        };

         Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .ForEach(action);
    }
}