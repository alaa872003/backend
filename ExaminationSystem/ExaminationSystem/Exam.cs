using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class Exam
    {
        public QuestionList Questions { get; set; } = new QuestionList();
        public AnswerList StudentAnswerList { get; set; } = new AnswerList();
        public Dictionary<Question, Answer> ModelAnswer { get; set; } = new Dictionary<Question, Answer>();

        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public TimeSpan QueuingTime { get; set; }
        public int NumOfQuest { get; set; }
        public int Grade { get; set; }
        public string? FileContent { get; set; }



       

        public int CalculateGrade(AnswerList studentAnswers)
        {
            int grade = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                Question question = (Question)Questions[i];
                if ( studentAnswers[i].GetHashCode()==ModelAnswer[question].GetHashCode())
                {
                    grade += question.Marks;
                }
                else
                {
                    grade = grade;
                }
            }
            return grade;
        }
        public Dictionary<Question, Answer> GetModelAnswer()
        {
            return ModelAnswer;
        }


    }
}

