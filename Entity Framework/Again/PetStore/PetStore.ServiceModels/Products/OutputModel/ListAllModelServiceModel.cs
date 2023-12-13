using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.Products.OutputModel
{
    public class ListAllModelServiceModel
    {
        public string Name { get; set; }

        public string ProductType { get; set; }
            
        public decimal Price { get; set; }
    }
}
