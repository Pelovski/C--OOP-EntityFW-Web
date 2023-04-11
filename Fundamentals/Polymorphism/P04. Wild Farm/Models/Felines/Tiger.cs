using System.Net.Http.Headers;

namespace P04._Wild_Farm.Models.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            var gainedWeight = quantity;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
           return "ROAR!!!";
        }
    }
}
