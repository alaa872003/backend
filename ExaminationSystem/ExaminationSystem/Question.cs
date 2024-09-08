using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Question
    {
        public string Body { get; set; }
        public int Marks { get; set; }
        public string Header { get; set; }
        public Answer CorrectAnswer { get; set; } 

        public Question(string header, string body, int marks)
        {
            Body = body;
            Marks = marks;
            Header = header;
        }

        public override string ToString()
        {
            return $"Question Added:{Header}:{Body}\t\tMarks:{Marks}";

        }

        public override int GetHashCode()
        {
            int hash = 17 ;
            hash = hash * 23 + Header.GetHashCode() ;
            hash = hash * 23 + Body.GetHashCode() ;
            hash = hash * 23 + Marks.GetHashCode();
            return hash;
        }
    }
}
