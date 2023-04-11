using System.Text;

namespace P01._Vehicles.Models
{
    internal class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION, tankCapacity)
        {
        }
    }
}
