using PetStore.Comman;
using PetStore.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.ProductNameMinLength)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }
        
        [Range(GlobalConstatnts.MinPriceValue, GlobalConstatnts.MaxPriceValue)]
        public decimal Price { get; set; }
    }
}
