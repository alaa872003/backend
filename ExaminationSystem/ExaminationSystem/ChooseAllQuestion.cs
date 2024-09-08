using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class ChooseAllQuestion : Question
    {
        public string[] Choices { get; set; }
        public List<Answer> CorrectChoices { get; set; }
        public ChooseAllQuestion(string header, string body, int marks, string[] choices, List<Answer> correctAnswers) : base(header, body, marks)
        {
            Choices=choices;
            CorrectChoices=correctAnswers;
        }

        public override string ToString()
        {

            return $"Question Added:{Header}:{Body}\tChoices( {Choices[0]}-{Choices[1]}-{Choices[2]}-{Choices[3]} )\t \t[Marks:{Marks}]";
        }


    }
    }
