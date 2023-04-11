namespace P04._Wild_Farm.Models.Mamals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            var gainedWeight = quantity * 0.40;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
            return "Woof";
        }
    }
}
