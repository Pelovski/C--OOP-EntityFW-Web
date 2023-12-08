using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        public IEnumerable<DistrictViewModel> GetTopDistrictsByAvaragePrice(int count = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties()
        {
            throw new NotImplementedException();
        }
    }
}
