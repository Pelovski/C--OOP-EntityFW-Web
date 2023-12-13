using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Data;
using PetStore.Comman;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModel;
using PetStore.Services.Contracts;
using System.Net.Http.Headers;

namespace PetStore.Services
{
    public class ProductService : IProductService
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
            try
            {

                var product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public ICollection<ListAllModelServiceModel> GetAll()
        {
            var products = this.dbContext
                .Products
                .ProjectTo<ListAllModelServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr)
        {
            var products = this.dbContext
                .Products
                .Where(p => p.Name.ToLower().Contains(searchStr.ToLower()))
                .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public ICollection<ListAllProductsByProductTypeService> ListAllByProductType(string type)
        {
            ProductType productType;

            var hasParsed = Enum.TryParse(type, true, out productType);

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

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbContext
                .Products.Find(id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowAfected = this.dbContext.SaveChanges();

            bool wasDeleted = rowAfected == 1;

            return wasDeleted;

        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this.dbContext.Products.FirstOrDefault(p => p.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);

            int rowAfected = this.dbContext.SaveChanges();

            bool wasDeleted = rowAfected == 1;

            return wasDeleted;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                var product = this.mapper.Map<Product>(model);

                var productToUpdate = this.dbContext.Products.Find(id);

                if (product == null)
                {
                    throw new ArgumentException(ExceptionMessages.ProductNotFound);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();

            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch(Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

         return success;

        }
    }
}
