using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Answer
    {
        public string AnswerText { get; set; }

        public Answer(string answerText)
        {
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"{AnswerText}\n";
        }

        public static bool operator ==(Answer lhs, Answer rhs)
        {
            if (lhs.AnswerText==rhs.AnswerText)
            {
                return true;
            }

                return false;
        }


        public static bool operator !=(Answer lhs, Answer rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Answer answer&& this.GetHashCode() == answer.GetHashCode())
            {
                return base.Equals(obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 18;
            hash = hash * 24 + GetHashCode();
            
            return hash;

        }
    }
}
