namespace P06._Speed_Racing
{
    public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model= model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(int distance)
        {
            double fuelNeeded = distance * this.FuelConsumptionPerKilometer;

            if (fuelNeeded < this.FuelAmount)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive.");
            }
        }
    }
}
