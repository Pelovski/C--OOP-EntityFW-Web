namespace P01._Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption  { get; set; }

        public double Distance { get; set; }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded > this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            this.FuelQuantity -= fuelNeeded;
            this.Distance += distance;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
