internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
  
        for (int i = 0; i < input.Length; i++)
        {

            bool isBigger = true;

            for (int j = i +1; j < input.Length; j++)
            {
                if (input[i] <= input[j])
                {
                    isBigger = false;
                }
            }

            if (isBigger)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}