using P04.Pizza_Calories.Common;

namespace P04.Pizza_Calories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }


        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!DoughValidator.IsValidFlourType(value))
                {
                    throw new Exception(GlobalConstants.InvalidType);
                }
                this.flourType = value;
            }
        }


        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!DoughValidator.IsValidBakingTechnique(value.ToLower()))
                {
                    throw new Exception(GlobalConstants.InvalidType);
                }
                this.bakingTechnique = value;
            }
        }



        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return (this.weight * GlobalConstants.BASE_CALORIES) *
                DoughValidator.GetFlourModifier(this.FlourType) *
                DoughValidator.GetBakingTechniqueModifier(this.BakingTechnique);
        }

    }
}
