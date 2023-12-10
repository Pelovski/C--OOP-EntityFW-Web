using PetStore.Models;
using PetStore.Comman;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetStore.Data.Configurations
{
    public class BreedEntityConfiguratin : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder
                .Property(b => b.Name)
                .HasMaxLength(GlobalConstatnts.BreedNameMaxLength)
                .IsUnicode(true);
        }
    }
}
