using System.Text;

namespace P01._Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount - (fuelAmount * 0.05);
        }
    }
}
