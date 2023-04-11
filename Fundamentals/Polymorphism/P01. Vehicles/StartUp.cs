using P01._Vehicles.Models;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var car = CreateVehicle();
        var truck = CreateVehicle();

        var vehicles = new List<Vehicle> {car, truck};

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commands = Console.ReadLine()
                .Split()
                .ToArray();

            string action = commands[0];
            string type = commands[1];
            double amount = double.Parse(commands[2]);

            var currentVehicle = vehicles.First(x => x.GetType().Name == type);

            if (action == "Drive")
            {
                currentVehicle.Drive(amount);
            }
            else
            {
                currentVehicle.Refuel(amount);
            }
        }

        PrintVehicles(vehicles);

    }

    private static void PrintVehicles(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }

    private static Vehicle CreateVehicle()
    {
        string[] input = Console.ReadLine()
            .Split()
            .ToArray();

        string type = input[0];
        double fuelQuantity = double.Parse(input[1]);
        double litersPerKm = double.Parse(input[2]);

        if (type == "Car")
        {
            return new Car(fuelQuantity, litersPerKm);
        }

        return new Truck(fuelQuantity, litersPerKm);
    }
}