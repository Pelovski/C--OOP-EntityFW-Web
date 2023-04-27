using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Models;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Models;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths.Models
{
    public class Booth : IBooth
    {
        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;

        private int capacity;
        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity= capacity;

            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();

            this.CurrentBill= 0;
            this.Turnover = 0;
        }

        public int BoothId { get; }

        public int Capacity
        {
            get => this.capacity;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacies;

        public IRepository<ICocktail> CocktailMenu => this.cocktails;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
          this.IsReserved = true ? this.IsReserved = false : this.IsReserved = true;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill= 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill= amount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Booth: {this.BoothId}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Turnover: {this.Turnover:f2} lv")
                .AppendLine("-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
