using PetStore.Comman;
using PetStore.Models.Enumerations;

using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Products.InputModels
{
    public class EditProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstatnts.ProductNameMinLength)]
        [MaxLength(GlobalConstatnts.ProductNameMaxLength)]
        public string Name { get; set; }

        public string ProductType { get; set; }

        [Range(GlobalConstatnts.MinPriceValue, GlobalConstatnts.MaxPriceValue)]
        public decimal Price { get; set; }
    }
}
