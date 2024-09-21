using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public enum ResourceTypes
    {
        Video=1,
        Presentation=2,
        Document=3,
        Other=4
    }
    internal class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public ResourceTypes ResourceType { get; set; }
        public int CourseId { get; set; }

    }
}
