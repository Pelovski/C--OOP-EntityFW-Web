using AutoMapper;

using PetStore.Data;
using PetStore.Comman;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using AutoMapper.QueryableExtensions;
using PetStore.ServiceModels.Products.OutputModel;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            var product = this.mapper.Map<Product>(model);

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllProductsByProductTypeService> ListAllByProductType(string type)
        {
            ProductType productType;

            var hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext
                                          .Products
                                          .Where(p => p.ProductType == productType)
                                          .ProjectTo<ListAllProductsByProductTypeService>(this.mapper.ConfigurationProvider)
                                          .ToList();

            return productsServiceModels;
        }

    }
}
