internal class Program
{
    private static void Main(string[] args)
    {
        int startingYield = int.Parse(Console.ReadLine()); //  10 less every day
        int days = 0;
        int extractedSpices = 0;

        while (startingYield > 100)
        {
            days++;
            extractedSpices += startingYield;
            startingYield -= 10;
            extractedSpices -= 26;

        }

        extractedSpices -= 26;

        Console.WriteLine(days);
        Console.WriteLine(extractedSpices);
    }
}