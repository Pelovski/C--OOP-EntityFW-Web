using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IDistrictService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictsByAvaragePrice(int count = 10);

        IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10);

    }
}
