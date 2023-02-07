namespace P07._Raw_Data
{
    internal class Cargo
    {
        public Cargo(string cargoType, int cargoWeight)
        {
            this.CargoType= cargoType;
            this.CargoWeight= cargoWeight;
        }
        public string CargoType { get; set; }

        public int CargoWeight { get; set; }
    }
}
