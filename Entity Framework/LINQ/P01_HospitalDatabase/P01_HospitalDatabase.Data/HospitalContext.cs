using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
                
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                .Property(p => p.Email)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity
                .HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity
                .HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.PatientMedicaments)
                .HasForeignKey(pm => pm.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

                entity
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PatientMedicaments)
                .HasForeignKey(pm => pm.MedicamentId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
