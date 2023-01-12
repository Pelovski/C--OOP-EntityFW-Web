 class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

   
        int elemetsToPush = int.Parse(input[0]);
        int elementsToPop = int.Parse(input[1]);
        int findElement = int.Parse(input[2]);

        var data = new Stack<int>();

        string[] numbersInput = Console.ReadLine().Split(' ');

        for (int i = 0; i < elemetsToPush - elementsToPop; i++)
        {
            data.Push(int.Parse(numbersInput[i]));
        }
        
        bool isContain = data.Contains(findElement);

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