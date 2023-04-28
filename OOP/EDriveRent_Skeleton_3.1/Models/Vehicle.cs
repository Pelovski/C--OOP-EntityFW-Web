using System;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;
        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;

            this.BatteryLevel = 100;
        }

        public string Brand 
        {
            get => this.brand;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }

                this.brand = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }

                this.model = value;
            }
        }

        public double MaxMileage { get; } // пробег

        public string LicensePlateNumber
        {
            get => this.licensePlateNumber;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }

                this.licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void ChangeStatus()
        {
            this.IsDamaged = true ? false : true;
        }
        public void Drive(double mileage)
        {
            var bateryProcentUse = Math.Round((mileage - this.MaxMileage) * 100);

            if (this.GetType().Name == nameof(CargoVan))
            {
                bateryProcentUse += 5;
            }

            this.BatteryLevel -= (int)bateryProcentUse;
        }
        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public override string ToString()
        {
            string isDamaged = this.IsDamaged == true ? "OK" : "damaged";

            return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status:{isDamaged}";
        }
    }
}
