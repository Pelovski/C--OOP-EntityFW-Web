using System.Xml.Linq;
using P04.Pizza_Calories.Models;

namespace P04.Pizza_Calories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaIutput = Read();
                string[] douthInput = Read();

                var dough = CreateDough(douthInput);
                var pizza = CreatePizza(pizzaIutput, dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    var topping = CreateTopping(input);

                    pizza.AddToping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Pizza CreatePizza(string[] name, Dough dough)
        {
            return new Pizza(name[1], dough);
        }
        public Topping CreateTopping(string input)
        {
            string toppingType = input.Split()[1];
            double toppingWeight = double.Parse(input.Split()[2]);

            return new Topping(toppingType, toppingWeight);
        }
        public Dough CreateDough(string[] input)
        {
            string flourType = input[1];
            string bakingTechnique = input[2];
            double weight = double.Parse(input[3]);

            return new Dough(flourType, bakingTechnique, weight);
        }
        public string[] Read() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}
