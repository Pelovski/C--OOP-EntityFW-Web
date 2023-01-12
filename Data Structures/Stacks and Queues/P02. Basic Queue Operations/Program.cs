 class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

        int elementsCount = int.Parse(input[0]);
        int removeElementsCount = int.Parse(input[1]);
        int targetElement = int.Parse(input[2]);

        var data = new Queue<int>();

        string[] elements = Console.ReadLine().Split(' ');

        for (int i = removeElementsCount; i < elementsCount; i++)
        {
            data.Enqueue(int.Parse(elements[i]));
        }

        bool isContain = data.Contains(targetElement);

        if (!isContain)
        {
            if (!data.Any())
            {
                Console.WriteLine(0);
            }

            else
            {
                Console.WriteLine(data.Min());
            }
           
        }
         else
        {
            Console.WriteLine(isContain);
        }
    }
}