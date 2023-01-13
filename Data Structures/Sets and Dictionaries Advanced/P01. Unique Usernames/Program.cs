 class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = new HashSet<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            data.Add(input);
        }

        Console.WriteLine(String.Join("\n", data));
    }
}