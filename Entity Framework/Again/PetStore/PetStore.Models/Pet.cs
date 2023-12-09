using PetStore.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id =  Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public byte Age { get; set; }

        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        [Required]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }



    }
}
