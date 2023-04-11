namespace P04._Wild_Farm.Models.Mamals
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            var gainedWeight = quantity * 0.10;

            this.Weight += gainedWeight;
            this.FoodEaten += quantity;
        }

        public override string ProducingSound()
        {
            return "Squeak";
        }
    }
}
