using PetStore.Models;
using PetStore.Comman;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetStore.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(pr => pr.Name)
                .HasMaxLength(GlobalConstatnts.ProductNameMaxLength)
                .IsUnicode(false);
        }
    }
}
