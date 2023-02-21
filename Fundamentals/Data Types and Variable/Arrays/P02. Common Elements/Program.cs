internal class Program
{
    private static void Main(string[] args)
    {
        string[] firstSentence = Console.ReadLine().Split(" ");
        string[] secondSentence = Console.ReadLine().Split(" ");

        string result = "";

            for (int i = 0; i < secondSentence.Length; i++)
        {
            for (int j = 0; j < firstSentence.Length; j++)
            {
                if (firstSentence[j] == secondSentence[i])
                {
                    result += secondSentence[i] + " ";
                }
            }
        }

        Console.WriteLine(result);

    }
}