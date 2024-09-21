using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public enum ContentTypes
    {
        Application=1,
        PDF=2,
        ZIP=3
    }
    internal class HomeWork
    {
        public int HomeWorkId { get; set; }
        public string Content { get; set; }
        public ContentTypes ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

    }
}
