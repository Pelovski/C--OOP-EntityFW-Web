using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P01._Student_System.Data.Models
{
    public class Student
    {

        public Student()
        {
            this.CourseEnrollments = new HashSet<Course>();
            this.HomeworkSubmissions = new HashSet<Homework>();

        }
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        [Column(TypeName = "varchar(MAX)")]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

    }
}
