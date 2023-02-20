internal class Program
{
    private static void Main(string[] args)
    {
        int n  = int.Parse(Console.ReadLine());
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
             char input = Console.ReadLine()[0];

            int currentValue = (int)input;

            sum+= currentValue;
        }

        Console.WriteLine($"The sum equals: {sum}");
    }
}