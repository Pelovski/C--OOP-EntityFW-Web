using P06._Vehicle_Catalogue;
using System;
using System.Collections.Generic;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var cars = new List<Car>();
        var trucks = new List<Truck>();
        CreateVehicle(cars, trucks);
        double carAvrage = AvrageHoursePowerByVehicle(cars);
        double truckAvrage = AvrageHoursePowerByVehicle(trucks);

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Close the Catalogue")
            {
                Console.WriteLine($"Cars have average horsepower of: {carAvrage:f2}");
                Console.WriteLine($"Cars have average horsepower of: {truckAvrage:f2}");

                break;
            }

            Vehicle vehicle = cars.Any(x => x.Model == input) ? cars.FirstOrDefault(x => x.Model == input) : trucks.FirstOrDefault(x => x.Model == input);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {vehicle.Type}")
                .AppendLine($"Model: {vehicle.Model}")
                .AppendLine($"Color: {vehicle.Color}")
                .AppendLine($"Horsepower: {vehicle.Horsepower}");

            Console.WriteLine(sb);
        }
    }

    private static double AvrageHoursePowerByVehicle(List<Car> vehicles)
    {
        double avrageSum = 0;
        foreach (var vehicle in vehicles)
        {
            avrageSum += vehicle.Horsepower;
        }

        return avrageSum /= vehicles.Count;
    }

    private static double AvrageHoursePowerByVehicle(List<Truck> vehicles)
    {
        double avrageSum = 0;
        foreach (var vehicle in vehicles)
        {
            avrageSum += vehicle.Horsepower;
        }

        return avrageSum /= vehicles.Count;
    }

    private static void CreateVehicle(List<Car> cars, List<Truck> trucks)
    {
        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "End")
            {
                break;
            }

            string type = input[0];
            string model = input[1];
            string color = input[2];
            int horsePower = int.Parse(input[3]);

            if (type == "car")
            {
                var car = new Car(model, color, horsePower);

                cars.Add(car);
            }
            else
            {
                var truck = new Truck(model, color, horsePower);

                trucks.Add(truck);
            }
        }
    }
}