using System.Data;
using P03._Shopping_Spree.Common;

namespace P03._Shopping_Spree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

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
                    throw new ArgumentNullException(GlobalConstants.InvalidNameExceptionMessage);
                }

               this.name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value < GlobalConstants.COST_MIN_VALUE)
                {
                    throw new ArgumentNullException(GlobalConstants.NegativeNumberExceptionMessage);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

    }
}
