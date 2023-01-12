 class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int command = int.Parse(input[0]);

            if (command == 1)
            {
                data.Push(int.Parse(input[1]));
            }

            else if (command == 2)
            {
                data.Pop();
            }
            else if (command == 3)
            {
                Console.WriteLine(data.Max());

            }

            else
            {
                Console.WriteLine(data.Min());
            }
        }

        string result = String.Join(", ", data.ToArray());

        Console.WriteLine(result);
    }
}