namespace EDriveRent.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;

    internal class UserRepository : IRepository<IVehicle>
    {
        private List<IVehicle> users;

        public UserRepository()
        {
            this.users = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
           this.users.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
           return this.users.Find(x => x.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.users as IReadOnlyCollection<IVehicle>;
        }

        public bool RemoveById(string identifier)
        {
            var user = this.users.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);

            return this.users.Remove(user);
        }
    }
}
