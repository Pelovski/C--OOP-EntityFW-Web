using P04._Wild_Farm.Models.Foods;

namespace P04._Wild_Farm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public virtual int FoodEaten { get; set; }

        public abstract void Eat(string foodType, int quantity);

        public abstract string ProducingSound();
    }
}
