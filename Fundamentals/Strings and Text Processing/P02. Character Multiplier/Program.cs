internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        char[] firstWord = input[0].ToCharArray();
        char[] secondWord = input[1].ToCharArray();

        int maxLength = Math.Max(firstWord.Length, secondWord.Length);
        int minLenght = Math.Min(firstWord.Length, secondWord.Length);

        int sum = 0;
        int count = 0;

        for (int i = 0; i < minLenght; i++)
        {

            sum += firstWord[i] * secondWord[i];
            count++;
        }

        if (count != maxLength)
        {
            var n = maxLength - minLenght;
           
        }

        Console.WriteLine(sum);
    }
}