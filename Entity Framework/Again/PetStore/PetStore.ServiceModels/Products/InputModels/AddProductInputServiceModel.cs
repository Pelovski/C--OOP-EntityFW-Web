using PetStore.Comman;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.Products.InputModels
{
    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstatnts.ProductNameMinLength)]
        [MaxLength(GlobalConstatnts.ProductNameMaxLength)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        [Range(GlobalConstatnts.MinPriceValue, GlobalConstatnts.MaxPriceValue)]
        public decimal Price { get; set; }
    }
}
