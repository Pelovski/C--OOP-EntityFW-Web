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
        [MinLength(3)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
