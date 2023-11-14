using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        public string Name  { get; set; }

        public string Url { get; set; }

        public ResourceType ResourceType  { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
