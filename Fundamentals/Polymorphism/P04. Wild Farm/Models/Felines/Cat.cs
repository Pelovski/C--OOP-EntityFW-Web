namespace P04._Wild_Farm.Models.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            var gainedWeight = quantity * 0.30;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
            return "Meow";
        }
    }
}
