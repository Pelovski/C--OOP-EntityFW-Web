namespace P06._Vehicle_Catalogue
{
    internal class Car : Vehicle
    {
        public Car(string model, string color, int horsepower)
            : base(model, color, horsepower)
        {
            this.Type = "Car";
        }
    }
}
