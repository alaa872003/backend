using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{

    public class ChooseOneQuestion : Question
    {
        public string[] Choices { get; set; }
        public Answer CorrectAnswer { get; set; }

        public ChooseOneQuestion(string header, string body, int marks, string[] choices, Answer correctAnswer) : base(header, body, marks)
        {
            Choices = choices;
            CorrectAnswer=correctAnswer;
                }


        public override string ToString()
        {


            return $"Question Added:{Header}:{Body}\tChoices({Choices[0]}-{Choices[1]}-{Choices[2]}-{Choices[3]})\t\tMarks:{Marks}";

        }

    }
}
