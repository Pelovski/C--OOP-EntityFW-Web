internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int waterTankCapacity = 255;
        int pourQuantity = 0;

        for (int i = 0; i < n; i++)
        {
            int liters = int.Parse(Console.ReadLine());

            if (waterTankCapacity >= liters)
            {
                waterTankCapacity -= liters;
                pourQuantity += liters;
            }

            else
            {
                Console.WriteLine("Insufficient capacity!");
            }
        }

        Console.WriteLine(pourQuantity);
    }
}