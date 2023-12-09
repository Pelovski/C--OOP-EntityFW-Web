using System.ComponentModel.DataAnnotations;
using PetStore.Comman;

namespace PetStore.Models
{
    public class Client
    {

        public Client()
        {
           this.Id = Guid.NewGuid().ToString();
            this.PetsBuyed = new HashSet<Pet>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.ClientUsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.ClientEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.ClientNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.ClientNameMinLength)]
        public string LastName { get; set; }

        public virtual ICollection<Pet> PetsBuyed { get; set; }
    }
}
