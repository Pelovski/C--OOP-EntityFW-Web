using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using PetStore.Models.Enumerations;

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
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public byte Age { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }
    }
}
