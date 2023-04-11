using P04._Wild_Farm.Models.Foods;

namespace P04._Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            var gainedWeight = quantity * 0.35;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
            return "Cluck";
        }
    }
}
