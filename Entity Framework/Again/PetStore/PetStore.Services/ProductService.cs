using PetStore.Data;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetStoreDbContext dbContext;

        public ProductService(PetStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddProduct()
        {

        }
    }
}
