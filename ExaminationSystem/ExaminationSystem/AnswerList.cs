using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class AnswerList : ArrayList
    {

        public override int Add(object? value)
        {
            if (value is Answer answer)
            {
                return base.Add(answer);
            }
            return 0;
        }

        public static bool operator ==(AnswerList lhs, AnswerList rhs)
        {
            if (lhs.Count != rhs.Count)
            {
                return false;
            }
            for (int i = 0; i < lhs.Count; i++)
            {
                if (!lhs[i].Equals(rhs[i]))
                {
                    return false;
                }
            }
            return true;
        }


        public  static bool operator !=(AnswerList lhs,AnswerList rhs)
          {
            return !(lhs == rhs);
        }

     
        public static void DisplayAnswerList(AnswerList answerList)
        {
           foreach (Answer answer in answerList) {
               Console.WriteLine(answer.ToString());
           } 
        }

    }
}
