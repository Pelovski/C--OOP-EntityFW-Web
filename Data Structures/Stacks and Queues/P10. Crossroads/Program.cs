 class Program
{
    private static void Main(string[] args)
    {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freewindowDuration = int.Parse(Console.ReadLine());

        int duration = greenLightDuration + freewindowDuration;
        int carsCount = 0;

        var cars = new Queue<string>();

        while (true)
        {
            string input = Console.ReadLine();

            int currnetGreen = greenLightDuration;
            int currentDuration = freewindowDuration;
            

            if (input == "END")
            {
                break;
            }

            if (input != "green")
            {
                cars.Enqueue(input);
            }
            else
            {
                int carsLength = cars.Count();

                for (int i = 0; i < carsLength; i++)
                {
                    string currentCar = cars.First();

                    if (currnetGreen > 0)
                    {
                        currnetGreen -= currentCar.Length;
                        currentDuration = currnetGreen + freewindowDuration;

                        if (currentDuration < 0)
                        {

                            char hittedChar = currentCar[currentCar.Length + currentDuration];

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {hittedChar}.");
                            return;
                        }

                        carsCount++;
                        cars.Dequeue();
                    }

                }
            }

        }

        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{carsCount} total cars passed the crossroads.");

    }
}