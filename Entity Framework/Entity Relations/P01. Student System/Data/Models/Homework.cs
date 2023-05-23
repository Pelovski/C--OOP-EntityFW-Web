using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using P01._Student_System.Data.Contracts;

namespace P01._Student_System.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "binary(MAX)")]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public TimeSpan SubmissionTime { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
