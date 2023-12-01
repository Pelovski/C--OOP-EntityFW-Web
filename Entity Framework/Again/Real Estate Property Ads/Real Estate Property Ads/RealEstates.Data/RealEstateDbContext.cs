using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class RealEstateDbContext : DbContext
    {       
        public RealEstateDbContext()
        {
        }

        public RealEstateDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<BuildingType> BuildingTypes { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }

        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }


       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Arsenal;Database=RealEstate;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RealEstatePropertyTag>()
                .HasKey(x => new { x.TagId, x.RealEstatePropertyId });

            modelBuilder
                .Entity<RealEstatePropertyTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Tags)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<RealEstatePropertyTag>()
                .HasOne(x => x.RealEstateProperty)
                .WithMany(x => x.Tags)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
