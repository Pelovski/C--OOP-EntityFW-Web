namespace P07._Raw_Data
{
    internal class Tire
    {
        public Tire(int age, double pressure)
        {
            this.Age= age;
            this.Pressure= pressure;
        }
        public int Age { get; set; }

        public double Pressure { get; set; }
    }
}
