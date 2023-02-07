namespace P07._Raw_Data
{
    internal class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model= model;
            this.Engine= engine;
            this.Cargo= cargo;
            this.Tires = new List<Tire>();
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tire> Tires { get; set; }
    }
}
