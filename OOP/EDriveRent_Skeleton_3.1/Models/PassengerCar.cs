namespace EDriveRent.Models
{ 
     public class PassengerCar : Vehicle
    {
        private const double PASSAGER_CAR_MAX_MILEAGE = 450;
        public PassengerCar(string brand, string model, string licensePlateNumber)
            : base(brand, model, PASSAGER_CAR_MAX_MILEAGE, licensePlateNumber)
        {

        }
    }
}
