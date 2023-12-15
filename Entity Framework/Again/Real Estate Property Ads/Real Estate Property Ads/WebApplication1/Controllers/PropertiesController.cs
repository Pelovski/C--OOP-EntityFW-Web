using Microsoft.AspNetCore.Mvc;
using RealEstates.Services;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController: Controller
    {
        private readonly IPropertyService propertiesService;

        public PropertiesController(IPropertyService propertyService)
        {
            this.propertiesService = propertyService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var properties = this.propertiesService.SearchByPrice(minPrice, maxPrice);

            return this.View(properties);
        }

        public IActionResult Sort()
        {
            return this.View();
        }
    }
}
