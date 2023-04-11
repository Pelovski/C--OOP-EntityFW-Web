using P04._Wild_Farm.Models.Foods;

namespace P04._Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            var gainedWeight = quantity * 0.25;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
            return "Hoot Hoot";
        }
    }
}
