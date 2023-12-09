using System.ComponentModel.DataAnnotations;
using PetStore.Comman;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.OrderTownMinLength)]
        public string Town { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.OrderAdressMinLength)]
        public string Adress { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        public decimal TotalPrice => this.ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity);
    }
}
