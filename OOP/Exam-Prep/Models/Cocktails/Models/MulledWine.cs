namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public class MulledWine : Cocktail
    {
        private const double LARGE_MULLEDWINE_PRICE = 13.50;
        public MulledWine(string cocktailName, string size)
            : base(cocktailName, size, LARGE_MULLEDWINE_PRICE)
        {
        }
    }
}
