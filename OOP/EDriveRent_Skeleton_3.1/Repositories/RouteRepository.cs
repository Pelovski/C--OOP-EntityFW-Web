namespace EDriveRent.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
           this.routes.Add(model);
        }

        public IRoute FindById(string identifier) => this.routes.FirstOrDefault(x => x.RouteId == int.Parse(identifier));

        public IReadOnlyCollection<IRoute> GetAll() => this.routes;

        public bool RemoveById(string identifier) => this.routes.Remove(this.FindById(identifier));

    }
}
