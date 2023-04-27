using System;
using System.Linq;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Booths.Models;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Models;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Models;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controler : IController
    {
        private IRepository<IBooth> booths;

        public Controler()
        {
            this.booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;

            var booth = new Booth(boothId, capacity);

            this.booths.AddModel(booth);

            return string
                .Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) || cocktailTypeName != nameof(MulledWine))
            {
                return string
                    .Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" || size != "Middle" || size != "Large")
            {
                return string
                    .Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (this.booths.Models.Any(x => x.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size)))
            {
                string
                    .Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);

            return string
                .Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Stolen" || delicacyTypeName != "Gingerbread")
            {
                return string
                    .Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (this.booths.Models.Any(x => x.DelicacyMenu.Models.Any(x => x.Name == delicacyName)))
            {
                return string
                    .Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return string
                .Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = this
                .booths
                .Models
                .FirstOrDefault(x => x.IsReserved == false && x.Capacity >= countOfPeople);

            if (booth == null)
            {
                return string
                    .Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string
                .Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orders = order.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orders[0];
            string itemName = orders[1];
            int countPiecesOrders = int.Parse(orders[2]);
            bool isCoctail = false;

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                isCoctail = true;
            }

            var booth = this.booths.Models.First(x => x.BoothId == boothId);

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string
                    .Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (isCoctail)
            {
                string size = orders[3];

                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName))
                {
                    return string
                        .Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }

        }
    }
}
