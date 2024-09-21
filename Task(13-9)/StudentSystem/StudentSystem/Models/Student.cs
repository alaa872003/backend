using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        public string? Birthday { get; set; } 
        public ICollection<Course> Courses { get; set; }=new List<Course>();
        public ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    }
}