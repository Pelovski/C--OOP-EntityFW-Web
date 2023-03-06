using System.Diagnostics;
using P01._Generic_Box_of_String;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var data = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            var box = new Box<string>(input);

            data.Add(box);

        }

        foreach (var item in data)
        {
            Console.WriteLine(item.ToString());
        }
    }
}