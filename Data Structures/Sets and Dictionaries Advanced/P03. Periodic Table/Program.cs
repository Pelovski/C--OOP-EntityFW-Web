 class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');



            for (int j = 0; j < input.Length; j++)
            {
                data.Add(input[j]);
            }
        }

        Console.WriteLine(String.Join(" ", data));
    }
}