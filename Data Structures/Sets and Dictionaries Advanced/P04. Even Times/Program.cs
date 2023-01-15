using System;
using System.Runtime.CompilerServices;

class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var data = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            if (!data.ContainsKey(input))
            {
                data.Add(input, 1);
            }

            data[input]++;

            
        }

        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}