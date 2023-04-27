namespace ChristmasPastryShop.Models.Delicacies.Models
{
    public class Gingerbread : Delicacy
    {
        private const double GINGERBREAD_PRICE = 4.00;
        public Gingerbread(string delicacyName)
            : base(delicacyName, GINGERBREAD_PRICE)
        {
        }
    }
}
