using System;

namespace P01._Student_System.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int MyProperty { get; set; }

        // public ResourceType  enum { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
