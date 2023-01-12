class Program
{
    private static void Main(string[] args)
    {
        int foodQuantity = int.Parse(Console.ReadLine());
        string[] orderQuantity = Console.ReadLine().Split(' ');
        var orders = new Queue<int>();

        for (int i = 0; i < orderQuantity.Length; i++)
        {
            orders.Enqueue(int.Parse(orderQuantity[i]));
        }

        int biggestOrder = orders.Max();

        while (foodQuantity > 0)
        {
            int currentOrder = orders.First();

            if (foodQuantity > currentOrder)
            {
                orders.Dequeue();
                foodQuantity -= currentOrder;
                Console.WriteLine("Orders complete.");
            }
            else
            {
                break;
            }


        }


        Console.Write("Orders left:{0}", String.Join(" ", orders.ToArray()));

    }
}