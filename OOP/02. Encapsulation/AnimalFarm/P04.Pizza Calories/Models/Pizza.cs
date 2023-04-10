using P04.Pizza_Calories.Common;

namespace P04.Pizza_Calories.Models
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public int ToppingsCount
            => this.toppings.Count();
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(GlobalConstants.EmptyInput);
                }

                if (value.Length <= 0 || value.Length > 15)
                {
                    throw new Exception(GlobalConstants.InvalidName);
                }

                this.name = value;
            }
        }

        public Dough Dough { get; }

        public double GetTotalCalories()
        => this.toppings.Sum(x => x.GetTotalCalories()) + this.Dough.GetTotalCalories();

        public void AddToping(Topping topping)
        {
            if (this.ToppingsCount == 10)
            {
                throw new Exception(GlobalConstants.InvalidToppingsCount);
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():F2} Calories.";
        }
    }
}
