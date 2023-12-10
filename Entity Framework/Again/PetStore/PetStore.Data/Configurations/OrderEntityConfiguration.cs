using PetStore.Models;
using PetStore.Comman;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetStore.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.Town)
                .HasMaxLength(GlobalConstatnts.OrderTownMaxLength)
                .IsUnicode(true);

            builder
               .Property(o => o.Adress)
               .HasMaxLength(GlobalConstatnts.OrderAdressMaxLength)
               .IsUnicode(true);
        }
    }
}
