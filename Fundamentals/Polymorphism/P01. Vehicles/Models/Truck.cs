using System.Text;

namespace P01._Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION, tankCapacity)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            double newFuelAmount = fuelAmount - (fuelAmount * 0.05);

            base.Refuel(newFuelAmount);
        }
    }
}
