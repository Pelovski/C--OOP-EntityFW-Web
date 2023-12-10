using PetStore.Models;
using PetStore.Comman;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetStore.Data.Configurations
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .Property(c => c.Username)
                .HasMaxLength(GlobalConstatnts.ClientUsernameMaxLength)
                .IsUnicode(false);

            builder
                .Property(c => c.Email)
                .HasMaxLength(GlobalConstatnts.ClientEmailMaxLength)
                .IsUnicode (false);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(GlobalConstatnts.ClientNameMaxLength)
                .IsUnicode (true);

            builder
               .Property(c => c.LastName)
               .HasMaxLength(GlobalConstatnts.ClientNameMaxLength)
               .IsUnicode(true);
        }
    }
}
