

using System.ComponentModel.DataAnnotations;

namespace P01._Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION = 1.4;

        private string statment;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION, tankCapacity)
        {

        }
    }
}
