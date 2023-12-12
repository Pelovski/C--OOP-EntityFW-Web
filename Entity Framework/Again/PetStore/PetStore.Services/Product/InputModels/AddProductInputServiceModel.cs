using PetStore.Comman;
using PetStore.Models.Enumerations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PetStore.Services.Product.InputModels
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
