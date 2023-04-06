namespace P04.Pizza_Calories
{
    public class Pizza
    {
        public Pizza(string name, Dough dough, Topping topping)
        {
            this.Name = name;
            this.Dough = dough;
            this.Topping = new List<Topping>();
        }

        public string Name { get; set; }
        public Dough Dough { get; set; }

        public List<Topping> Topping { get; set; }

    }
}
