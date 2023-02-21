internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        string topNumbers = "";
  
        for (int i = 0; i < input.Length; i++)
        {
            int counter = 0;
            for (int j = i; j < input.Length; j++)
            {
                if (j != input.Length -1 && input[i] > input[j + 1])
                {
                    counter++;
                }
            }

            if (counter == input.Length -1 -i)
            {
                topNumbers += input[i] + " ";
            }
        }

        Console.WriteLine(topNumbers);
    }
}