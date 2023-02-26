internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var data = new Dictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            char[] letters = input[i].ToCharArray();

            for (int j = 0; j < letters.Length; j++)
            {
                char letter = letters[j];

                if (!data.ContainsKey(letter))
                {
                    data.Add(letter, 0);
                }

                    data[letter]++;

            }
        }

        foreach (var letter in data)
        {
            Console.WriteLine($"{letter.Key} -> {letter.Value}");
        }
    }
}