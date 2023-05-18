using System;
using System.ComponentModel.DataAnnotations;

namespace P01._Student_System.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber  { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday  { get; set; }
    }
}
