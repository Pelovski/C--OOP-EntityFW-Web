namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const double PASSAGER_CAR_MAX_MILEAGE = 180;
        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, PASSAGER_CAR_MAX_MILEAGE, licensePlateNumber)
        {
        }
    }
}
