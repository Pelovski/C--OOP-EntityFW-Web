namespace EDriveRent.Models
{
    using System;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;

    public  class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicense;
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
           this.FirstName = firstName;
           this.LastName = lastName;
           this.DrivingLicenseNumber = drivingLicenseNumber;

            this.Rating = 0;
        }

        public string FirstName 
        {
            get => this.firstName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }

                this.lastName = value;
            }
        }

        public double Rating { get; private set; }

        public string DrivingLicenseNumber
        {
            get => this.drivingLicense;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }

                this.drivingLicense = value;
            }
        }

        public bool IsBlocked { get; private set; }

        public  void DecreaseRating()
        {
            this.Rating -= 2;

            if (this.Rating < 0)
            {
                this.Rating = 0;
                this.IsBlocked= true;
            }
        }
        public  void IncreaseRating()
        {
            this.Rating += 0.5;

            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";
        }
    }
}
