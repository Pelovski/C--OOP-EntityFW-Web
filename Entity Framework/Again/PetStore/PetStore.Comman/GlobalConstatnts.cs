namespace PetStore.Comman
{
    public static class GlobalConstatnts
    {

        //Global

        public const int MinPriceValue = 1;
        public const int MaxPriceValue = Int32.MaxValue;

        // Breed
        public const int BreedNameMinLength = 5;
        public const int BreedNameMaxLength = 30;

        //Client
        public const int ClientUsernameMinLength = 6;
        public const int ClientUsernameMaxLength = 30;

        public const int ClientEmailMinLength = 6;
        public const int ClientEmailMaxLength = 50;

        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 30;

        public const int QuantityMinValue = 30;
        public const int QuantityMaxValue = 30;

        //Order
        public const int OrderTownMinLength = 3;
        public const int OrderTownMaxLength = 30;

        public const int OrderAdressMinLength = 5;
        public const int OrderAdressMaxLength = 70;

        //Pet

        public const int PetNameMinLength = 3;
        public const int PetNameMaxLength = 30;

        public const int PetAgeMinValue = 1;
        public const int PetAgeMaxValue = 200;

        //Product

        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 30;

    }
}
