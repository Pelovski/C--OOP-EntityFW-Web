using System.Runtime.CompilerServices;

namespace P04.Pizza_Calories.Models
{
    public static class ToppingValidator
    {

        private static Dictionary<string, double> toppings;

        public static bool IsValid(string type)
        {

            Initalize();
            return toppings.ContainsKey(type.ToLower());

        }

        public static double GetToppingModifier(string type)
        {
            Initalize();
            return toppings[type.ToLower()];
        }
        private static void Initalize()
        {
            if (toppings != null)
            {
                return;
            }

            toppings = new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };
        }

    }
}
