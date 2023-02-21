internal class Program
{
    private static void Main(string[] args)
    {
        int pokePower = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        int exhaustionFactor = int.Parse(Console.ReadLine());
        int exaustRate = pokePower / 2;
        int targets = 0;

        while (pokePower > distance)
        {
            targets++;

            pokePower -= distance;

            if (pokePower == exaustRate && pokePower != 0 && exhaustionFactor != 0)
            {
                pokePower /= exhaustionFactor;
            }
        }

        Console.WriteLine(pokePower);
        Console.WriteLine(targets);
    }
}