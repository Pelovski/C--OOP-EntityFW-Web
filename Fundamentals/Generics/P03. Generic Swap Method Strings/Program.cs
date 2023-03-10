using System.Collections.Generic;
using P03._Generic_Swap_Method_Strings;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data =  new List<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            data.Add(input);
        }

        var box = new Box<string>(data);

        int[] indexToSwap = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        box.Swap(box.Values, indexToSwap[0], indexToSwap[1]);

        Console.WriteLine(box);
    }

}