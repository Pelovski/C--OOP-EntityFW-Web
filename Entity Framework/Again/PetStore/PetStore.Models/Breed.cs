using System.ComponentModel.DataAnnotations;
using PetStore.Comman;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstatnts.BreedNameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
