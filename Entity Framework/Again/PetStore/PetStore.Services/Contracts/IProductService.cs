using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModel;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);
        ICollection<ListAllModelServiceModel> GetAll();
        ICollection<ListAllProductsByProductTypeService> ListAllByProductType(string type);

        ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr);
        void EditProduct(string id, EditProductInputServiceModel model);
        bool RemoveById(string id);

        bool RemoveByName(string name);

    }
}
