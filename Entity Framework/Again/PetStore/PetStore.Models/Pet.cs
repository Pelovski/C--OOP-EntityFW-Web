using PetStore.Comman;
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
        [MinLength(GlobalConstatnts.PetNameMinLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(GlobalConstatnts.PetAgeMinValue, GlobalConstatnts.PetAgeMaxValue)]
        public byte Age { get; set; }

        [Range(GlobalConstatnts.MinPriceValue, GlobalConstatnts.MaxPriceValue)]
        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        [Required]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }



    }
}
