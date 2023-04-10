
using System.Xml.Linq;
using P04.Pizza_Calories.Common;

namespace P04.Pizza_Calories.Models
{
    public class Topping
    {
        private double weight;
        private string toppingType;
        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }

            private set
            {
                if (!ToppingValidator.IsValid(value))
                {
                    throw new Exception(string.Format(GlobalConstants.InvalidTopping, value));
                }
                this.toppingType = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new Exception(string.Format(GlobalConstants.InvalidWeight, this.ToppingType));
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return (this.Weight * GlobalConstants.BASE_CALORIES) *
                ToppingValidator.GetToppingModifier(this.ToppingType);
        }


    }
}
