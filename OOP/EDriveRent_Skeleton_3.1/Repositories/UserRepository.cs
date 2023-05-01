namespace EDriveRent.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;

    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            this.users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
           this.users.Add(model);
        }

        public IUser FindById(string identifier)
        {
           return this.users.Find(x => x.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this.users as IReadOnlyCollection<IUser>;
        }

        public bool RemoveById(string identifier)
        {
            var user = this.users.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);

            return this.users.Remove(user);
        }
    }
}
