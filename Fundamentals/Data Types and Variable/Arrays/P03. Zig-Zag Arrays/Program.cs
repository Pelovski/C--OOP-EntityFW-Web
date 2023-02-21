internal class Program
{
    private static void Main(string[] args)
    {
        int n  = int.Parse(Console.ReadLine());

        int[] firstArr = new int[n];
        int[] secountArr = new int[n];


        for (int i = 0; i < n; i++)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            if (i % 2 == 0)
            {
                firstArr[i] = input[0];
                secountArr[i] = input[1];
            }
            else
            {
                secountArr[i] = input[0];
                firstArr[i] = input[1];
            }
        }

        Console.WriteLine(string.Join(" ", firstArr));
        Console.WriteLine(string.Join(" ", secountArr));

    }
}