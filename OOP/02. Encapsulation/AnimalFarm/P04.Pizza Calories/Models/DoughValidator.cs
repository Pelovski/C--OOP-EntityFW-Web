namespace P04.Pizza_Calories.Models
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;

        public static bool IsValidFlourType(string type)
        {
            Initalize();
            return flourTypes.ContainsKey(type.ToLower());
        }
        public static bool IsValidBakingTechnique(string type)
        {
            Initalize();
            return bakingTechniques.ContainsKey(type.ToLower());
        }
        public static double GetFlourModifier(string type)
        {
            Initalize();
            return flourTypes[type.ToLower()];
        }
        public static double GetBakingTechniqueModifier(string type)
        {
            Initalize();
            return bakingTechniques[type.ToLower()];
        }
        private static void Initalize()
        {
            if (flourTypes != null && bakingTechniques != null)
            {
                return;
            }

            flourTypes = new Dictionary<string, double>
            {
                { "white", 1.5},
                {"wholegrain", 1 }
            };

            bakingTechniques = new Dictionary<string, double>
            {
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade", 1 }
            };
        }
    }
}
