using P07._Raw_Data;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(" ");

            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];


            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoType, cargoWeight);

            Car car = new Car(model, engine, cargo);

            for (int j = 5; j < 12; j+=2)
            {
                double tirePressure = double.Parse(input[j]);
                int tireAge = int.Parse(input[j+1]);

                Tire tire = new Tire(tireAge, tirePressure);

                car.Tires.Add(tire);
            }

            cars.Add(car);
            
        }

        var type = Console.ReadLine();

        if (type == "fragile")
        {
            cars
                .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(x => x.Pressure < 1))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Model));

        }

        if (type == "flamable")
        {
            cars
                .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.Power > 250)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Model));
        }
    }
}