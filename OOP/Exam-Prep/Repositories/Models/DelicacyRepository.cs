using System.Collections.Generic;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories.Models
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            this.delicacies= new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => this.delicacies;

        public void AddModel(IDelicacy model)
        {
            this.delicacies.Add(model); 
        }
    }
}
