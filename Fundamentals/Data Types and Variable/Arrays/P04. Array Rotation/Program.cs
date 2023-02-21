internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int rotation = int.Parse(Console.ReadLine());

      

        for (int i = 0; i < rotation; i++)
        {
            int firstNumber = input[0];

            for (int j = 0; j < input.Length -1; j++)
            {
                input[j] = input[j + 1];
            }

            input[input.Length -1] = firstNumber;
        }

        Console.WriteLine(string.Join(" ", input));
    }
}