namespace P06._Vehicle_Catalogue
{
    public class Truck : Vehicle
    {
        public Truck(string model, string color, int horsepower)
            : base(model, color, horsepower)
        {
            this.Type = "Truck";
        }
    }
}
