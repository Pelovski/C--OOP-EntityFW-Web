using System.Collections.Generic;
using System.Runtime.CompilerServices;
using P03._Shopping_Spree.Common;

namespace P03._Shopping_Spree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }
                this.name= value;
            }
        }

        public decimal Money 
        {
            get
            {
                return this.money;
            }

            private set 
            {
                if (value < GlobalConstants.MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.NegativeNumberExceptionMessage);
                }
            }
        }

        public IReadOnlyCollection<Product> Bag  => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(String.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.name, product.Name));
            }

            this.money -= product.Cost;

            this.bag.Add(product);
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ?
                String.Join(", ", this.Bag): "Nothing bought";
            return $"{this.Name} {productsOutput}";
        }

    }
}
