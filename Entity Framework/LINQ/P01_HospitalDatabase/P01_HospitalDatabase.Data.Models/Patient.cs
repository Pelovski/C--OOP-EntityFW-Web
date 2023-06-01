using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {

        public Patient()
        {
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
            this.PatientMedicaments = new HashSet<PatientMedicament>();
        }


        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string  LastName { get; set; }


        [Required]
        [MaxLength(250)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<PatientMedicament> PatientMedicaments { get; set; }


    }
}
