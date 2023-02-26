namespace P06._Vehicle_Catalogue
{
    public abstract class Vehicle : IVehicle
    {

        public Vehicle(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }
}
