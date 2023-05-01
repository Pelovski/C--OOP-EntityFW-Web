namespace EDriveRent.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    internal class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public IVehicle FindById(string identifier) =>  this.vehicles.FirstOrDefault(x => x.LicensePlateNumber == identifier);   

        public IReadOnlyCollection<IVehicle> GetAll() => this.vehicles;
      
        public bool RemoveById(string identifier) => this.vehicles.Remove(this.FindById(identifier));

        }
    }

