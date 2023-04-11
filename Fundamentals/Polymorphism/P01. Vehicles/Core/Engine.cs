using P01._Vehicles.Models;

namespace P01._Vehicles.Core
{
    public static class Engine
    {
        private static List<Vehicle> vehicles = new List<Vehicle>();

        public static void Run()
        {
            var car = CreateVehicle();
            var truck = CreateVehicle();
            var bus = CreateVehicle();

            vehicles = new List<Vehicle> { car, truck, bus };

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
                else if (action == "Refuel")
                {
                    currentVehicle.Refuel(amount);
                }

                else
                {
                    currentVehicle.DriveEmpty(amount);
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
            double tankCapacity = double.Parse(input[3]);

            if (type == "Car")
            {
                return new Car(fuelQuantity, litersPerKm, tankCapacity);
            }
            else if (type == "Truck")
            {
                return new Truck(fuelQuantity, litersPerKm, tankCapacity);
            }

            return new Bus(fuelQuantity, litersPerKm, tankCapacity);
        }
    }
}
