using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class PracticeExam : Exam
    {
        public PracticeExam(QuestionList questions, int num)
        {
            StartTime = DateTime.Now;
            FinishTime = StartTime.AddHours(1);
            Questions = questions;
            NumOfQuest = num;

            foreach (Question question in questions)
            {
                ModelAnswer[question] = question.CorrectAnswer;
            }
        }


       


}
}
