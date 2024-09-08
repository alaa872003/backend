using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class TrueOrFalseQuestion : Question
    {
        public Answer CorrectAnswer { get; set; }
        public TrueOrFalseQuestion(string header,string body, int marks ,Answer correctAnswer) : base(header, body, marks)
        {
            CorrectAnswer = correctAnswer;
        }

        public override string ToString()
        {
            return $"Question Added:{Header}:{Body} \t\tMarks:{Marks}";
        }
    }
}
