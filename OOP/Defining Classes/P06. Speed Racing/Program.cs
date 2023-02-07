using P06._Speed_Racing;

internal class Program
{
    private static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int i = 0; i < input; i++)
        {
            var data = Console.ReadLine()
            .Split(" ")
            .ToArray();

            string model = data[0];
            double fuelAmount = double.Parse(data[1]);
            double fuelConsumptionFor1km = double.Parse(data[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

            cars.Add(car);

        }

        while (true)
        {
            string[] driveInput = Console.ReadLine().Split(" ");

            if (driveInput[0] == "End")
            {
                break;
            }

            var currentCar = cars.First(x => x.Model == driveInput[1]);
            int distance = int.Parse(driveInput[2]);

            currentCar.Drive(distance);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}