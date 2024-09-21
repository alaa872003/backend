using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Price { get;  set; }
        public ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
