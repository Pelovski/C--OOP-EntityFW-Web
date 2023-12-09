using System.Linq.Expressions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly RealEstateDbContext db;

        public DistrictService(RealEstateDbContext db)
        {
           this.db = db;
        }
        public IEnumerable<DistrictViewModel> GetTopDistrictsByAvaragePrice(int count = 10)
        {
            return this.db.Districts
                   .OrderByDescending(x => x.Properties.Average(x => x.Price))
                   .Select(MapToDistrictViewModel())
                   .Take(count)
                   .ToList();
        }


        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            return this.db.Districts
                    .OrderByDescending(x => x.Properties.Count())
                    .Select(MapToDistrictViewModel())
                    .Take(count)
                    .ToList();
        }
        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return x => new DistrictViewModel
            {
                Name = x.Name,
                AvaragePrice = x.Properties.Average(x => x.Price),
                MinPrice = x.Properties.Min(x => x.Price),
                MaxPrice = x.Properties.Max(x => x.Price),
                PropertiesCount = x.Properties.Count()
            };
        }

    }
}
