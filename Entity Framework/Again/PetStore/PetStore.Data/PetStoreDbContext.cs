using PetStore.Comman;
using PetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
        {
        }
        public PetStoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ClientProduct> ClientProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionString);
            }

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder
                .Entity<ClientProduct>()
                .HasKey(cp => new {cp.ClientId, cp.ProductId });
        }
    }
}
