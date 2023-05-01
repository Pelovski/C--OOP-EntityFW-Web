using System.Collections.Generic;
using EDriveRent.Core.Contracts;
using EDriveRent.Models.Contracts;
using EDriveRent.Models;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.IO;
using EDriveRent.Utilities.Messages;
using System.Threading;
using System.Linq;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            this.users = new UserRepository();
            this.vehicles = new VehicleRepository();
            this.routes = new RouteRepository();
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
           int routeId = this.routes.GetAll().Count +1;

            IRoute isRouteExist = this.routes
                 .GetAll()
                 .FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint);

            if (isRouteExist != null)
            {
                if (isRouteExist.Length == length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }

                else if (isRouteExist.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint, length);
                }
                else
                {
                    isRouteExist.LockRoute();
                }
               
            }
            IRoute route = new Route(startPoint, endPoint, length, routeId);

            this.routes.AddModel(route);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = this.users.FindById(drivingLicenseNumber);
            IVehicle vehicle =  this.vehicles.FindById(licensePlateNumber);
            IRoute route = this.routes.FindById(routeId);

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }


            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser isUserExist = this.users.FindById(drivingLicenseNumber);

            if (isUserExist == null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            this.users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);

        }

        public string RepairVehicles(int count)
        {
            var damagedVechicles = this.vehicles
                .GetAll()
                .Where(x => x.IsDamaged)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .ToList();

            if (damagedVechicles.Count() < count)
            {
                damagedVechicles = damagedVechicles.Take(count).ToList();
            }

            foreach (var vehicle in damagedVechicles)
            {
                 vehicle.ChangeStatus();
                 vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles, damagedVechicles.Count);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            IVehicle isVehicleExist = this.vehicles.FindById(licensePlateNumber);

            if (vehicleType != nameof(CargoVan) || vehicleType != nameof(PassengerCar))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (isVehicleExist != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle;

            if (vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            this.vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string UsersReport()
        {
            throw new System.NotImplementedException();
        }
    }
}
