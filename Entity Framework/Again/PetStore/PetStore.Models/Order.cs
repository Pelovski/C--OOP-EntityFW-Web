using System.ComponentModel.DataAnnotations;


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
        [MinLength(3)]
        public string Town { get; set; }

        [Required]
        [MinLength(5)]
        public string Adress { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        public decimal TotalPrice => this.ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity);
    }
}
