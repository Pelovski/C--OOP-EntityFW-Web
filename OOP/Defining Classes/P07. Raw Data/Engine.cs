namespace P07._Raw_Data
{
    internal class Engine
    {

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power= power;
        }
        public int Speed { get; set; }

        public int Power { get; set; }
    }
}
