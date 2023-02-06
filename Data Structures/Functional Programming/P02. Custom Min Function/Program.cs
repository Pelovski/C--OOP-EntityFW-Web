internal class Program
{
    private static void Main(string[] args)
    {
        Func<int[], int> func =  x => x.Min();

        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(func(input));
    }
}