using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.PatientMedicaments= new HashSet<PatientMedicament>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<PatientMedicament> PatientMedicaments { get; set; }
    }
}
