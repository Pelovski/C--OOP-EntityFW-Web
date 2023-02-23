internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                int currentNum = input[i] + input[j];

                if (currentNum == number)
                {
                    Console.WriteLine($"{input[i]} {input[j]}");
                    break;
                }
            }
        }
    }
}