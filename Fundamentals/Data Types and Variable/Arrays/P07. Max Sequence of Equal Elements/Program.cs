internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int number = 0;
        int count = 1;
        int currentCount = 1;

        for (int i = 0; i < numbers.Length -1; i++)
        {
            int element = numbers[i];
            int nextElement = numbers[i + 1];

            if (element == nextElement)
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > count)
            {
                count = currentCount;
                number = element;
            }

        }

        for (int i = 0; i < count; i++)
        {
            Console.Write(number + " ");
        }

    }
}