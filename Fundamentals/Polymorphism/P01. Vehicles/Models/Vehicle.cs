namespace P01._Vehicles.Models
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption  { get; set; }

        public double Distance { get; set; }

        public double TankCapacity
        {
            get 
            {
                return tankCapacity; 
            }
            private set 
            {
                if (value < FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }


        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                return;
            }

            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

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

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= 1.4;
            this.Drive(distance);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
