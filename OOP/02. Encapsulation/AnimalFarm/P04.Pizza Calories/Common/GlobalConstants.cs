namespace P04.Pizza_Calories.Common
{
    public static class GlobalConstants
    {
        public static double BASE_CALORIES = 2;

        public static string InvalidType = "Invalid type of dough.";

        public static string InvalidToppingsCount = "Number of toppings should be in range [0..10].";

        public static string EmptyInput = "The name cannot be an empty string";

        public static string InvalidName = "Pizza name should be between 1 and 15 symbols.";

        public static string InvalidWeight = $"{0} weight should be in the range [1..50].";

        public static string InvalidTopping = $"Cannot place {0} on top of your pizza.";
    }
}
