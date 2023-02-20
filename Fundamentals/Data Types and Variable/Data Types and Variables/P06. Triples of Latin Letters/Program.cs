internal class Program
{
    private static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        string result = "";

        for (int i = 0; i < input; i++)
        {
            char firstChar = (char) ('a' + i);

            for (int j = 0; j < input; j++)
            {
                char secondChar = (char)('a' + j);

                for (int k = 0; k < input; k++)
                {
                    char thirdChar = (char)('a' + k);

                    Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");

                }
            }

            
        }
    }
}