using PetStore.Models;
using PetStore.Comman;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Data.Configurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(GlobalConstatnts.PetNameMaxLength)
                .IsUnicode(true);

            builder
               .Property(p => p.Price)
               .HasColumnType("decimal(18,4)");
        }
    }
}
