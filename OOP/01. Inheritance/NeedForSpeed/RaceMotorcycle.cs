namespace NeedForSpeed
{
    public class RaceMotorcycle : Vehicle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }
    }
}
