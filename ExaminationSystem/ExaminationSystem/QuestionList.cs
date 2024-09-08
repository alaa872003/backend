using System;
using System.Collections;
using System.IO;

namespace ExaminationSystem
{

    public class QuestionList : ArrayList
    {
        public string filePath { get; set; }
        public AnswerList ModelAnswersList { get; set; }
        public int questionMark { get; set; }
        public Question question { get; set; }
        public int c { get; set; }
        public QuestionList()
        {
            filePath = $"D:\\QuestionList_{++c}.txt";
            ModelAnswersList = new AnswerList();
        }

        public override int Add(object? value)
        {
           
            if (value is Question q)
            {
                using (TextWriter tw = new StreamWriter(filePath, true))
                {
                    tw.WriteLine(q);
                   
                }
                return base.Add(q);
            }
            return 0;
        }


        public void AddAnswer(Answer answer)
        {
            ModelAnswersList.Add(answer);
        }

    }
}
