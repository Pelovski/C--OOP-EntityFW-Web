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

            else
            {
                data[input]++;
            }
            
        }


        foreach (var item in data)
        {
            if (item.Value % 2 == 0)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}