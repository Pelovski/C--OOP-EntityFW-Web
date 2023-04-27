using System.Collections.Generic;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories.Models
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> cocktails;

        public CocktailRepository()
        {
            this.cocktails= new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => this.cocktails;

        public void AddModel(ICocktail model)
        {
            this.cocktails.Add(model);
        }
    }
}
