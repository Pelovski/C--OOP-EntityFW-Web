internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        var result = new List<string>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length >= 3 && input[i].Length <=16)
            {
                if (input[i].All(c => char.IsLetterOrDigit(c) || c == '-' || c == '!'))
                {
                    result.Add(input[i]);
                }
            }
        }

        Console.WriteLine(string.Join("\n", result));
    }
}