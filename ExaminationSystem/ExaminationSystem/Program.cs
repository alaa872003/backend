using System;
using System.Collections.Generic;

namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string? userType;
            QuestionList questionLists = new QuestionList();          
            AnswerList answerList = new AnswerList();
            do
            {

                Console.WriteLine("Are you student or teacher?(write\"exit\" to leave)");
                userType = Console.ReadLine();
                Question question;
                if (userType.ToLower().Equals("teacher"))
                {

                    Console.WriteLine("How many question you want?");
                    int qNum = int.Parse(Console.ReadLine());

                    for (int i = 0; i < qNum; i++)
                    {

                        Console.WriteLine("Type of question you want?");
                        Console.WriteLine("1) True or false");
                        Console.WriteLine("2) Choose one answer");
                        Console.WriteLine("3) Choose multiple answer");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the question level:");
                        string? level = Console.ReadLine();
                        Console.WriteLine("Enter the Question:");
                        string? quest = Console.ReadLine();
                        Console.WriteLine("Question Marks?");
                        int mark = int.Parse(Console.ReadLine());
                       
                        switch (n)
                        {
                            case 1:
                                Answer answer;
                                do
                                {

                                    Console.Write("Question Answer :(true / false)");

                                    answer = new Answer(Console.ReadLine().ToLower());

                                } while (!(answer.AnswerText.Equals("true") || answer.AnswerText.Equals("false")));
                                Console.WriteLine("====================================");

                                answerList.Add(answer);
                                question = new TrueOrFalseQuestion("True or false", quest, mark, answer);
                                question.CorrectAnswer = answer;

                                questionLists.Add(question);

                                break;
                            case 2:
                                string[] Choices = new string[4];

                                Console.Write($"Enter the chioce number 1:");
                                Choices[0] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 2:");
                                Choices[1] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 3:");
                                Choices[2] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 4:");
                                Choices[3] = Console.ReadLine();
                                Console.Write("Question Answer :(1 / 2 / 3 / 4 )");
                                 answer = new Answer(Console.ReadLine());
                                answerList.Add(answer);
                                question = new ChooseOneQuestion("Choose one answer", quest, mark, Choices, answer);
                                question.CorrectAnswer = answer;
                                questionLists.Add(question);

                                Console.WriteLine("====================================");

                                break;
                            case 3:
                                string[] multipleChoices = new string[4];
                                Console.Write($"Enter the chioce number 1:");
                                multipleChoices[0] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 2:");
                                multipleChoices[1] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 3:");
                                multipleChoices[2] = Console.ReadLine();
                                Console.Write($"Enter the chioce number 4:");
                                multipleChoices[3] = Console.ReadLine();
                                Console.Write("Question Answer(can choose more one answer if finish press f):(1 / 2 / 3 / 4 )");
                               List<Answer> correctChoices=new List<Answer>();
                                while (true)
                                {
                                string? choice=Console.ReadLine();
                                    if (choice.ToLower().Equals("f"))
                                    {
                                        break;
                                    }
                                answer = new Answer(choice);
                                answerList.Add(answer);
                                correctChoices.Add(answer);
                                }

                                question = new ChooseAllQuestion("Choose multiple answer", quest, mark, multipleChoices, correctChoices);

                                questionLists.Add(question);
                                Console.WriteLine("====================================");

                                break;
                        }

                    }
                }
                else if (userType.ToLower().Equals("student"))
                {
                    Console.WriteLine("Type of exam you want?");
                    Console.WriteLine("1) practice exam");
                    Console.WriteLine("2) final exam");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number of question :");
                    int numOfQuest =int.Parse(Console.ReadLine());
                    AnswerList studentAnswerList = new AnswerList();
                    Exam exam;
                    Answer answer;
                    string? answerText;
                    string filePath = $"D:\\QuestionList_{questionLists.c}.txt";
                    switch (n)
                    {
                        case 1:

                            exam = new PracticeExam(questionLists, numOfQuest);
                            Console.WriteLine($"Now,solve the Practice\nstarting time:{exam.StartTime}\nFinish time:{exam.FinishTime}");

                            using (TextReader tr = new StreamReader(filePath))
                            {
                                for (int i = 1; i <= numOfQuest; i++)
                                {
                                    string? fileContent = tr.ReadLine();

                                    if (fileContent != null)
                                    {
                                        Console.WriteLine($"\n\n{i}){fileContent}");
                                        answerText = Console.ReadLine();
                                        answer = new Answer(answerText);
                                    }
                                }              
                             }
                                Dictionary<Question, Answer> modelAnswers = exam.GetModelAnswer();
                                for (int i = 1; i <= numOfQuest; i++)
                                {

                                    foreach (var ma in modelAnswers)
                                    {
                                        Console.WriteLine($"Question{i}: {ma.Key.Header}:{ma.Key.Body},\tAnswer: {ma.Value.AnswerText}\t\t[Mark:{ma.Key.Marks}]\n\n");
                                    }
                                }
                             
                            Console.WriteLine("====================================");

                            break;
                        case 2:
                            
                            exam = new FinalExam(questionLists, numOfQuest);
                            Console.WriteLine($"Now,solve the exam\nstarting time:{exam.StartTime}\nFinish time:{exam.FinishTime}");
                            using (TextReader tr = new StreamReader(filePath))
                            {


                                 for (int i = 1; i <= numOfQuest; i++)
                                 {
                                    string? fileContent = tr.ReadLine();

                                    if (fileContent != null)
                                    {
                                    Console.WriteLine($"\n\n{i}){fileContent}");
                                    answerText = Console.ReadLine();
                                    answer = new Answer(answerText);
                                    studentAnswerList.Add(answer);
                                    }
                                 }
                            }
                            Console.WriteLine($"The grade of exam:{ exam.CalculateGrade(studentAnswerList)}");

                            Console.WriteLine("\n====================================");
                        break;

                    }
                    Console.WriteLine("Iam student");
                }
            
                else if (userType != "exit")
                {
                    Console.WriteLine("wrong choice..\n Try again");
                }
            } while (!userType.Equals("exit"));
            Console.WriteLine("after loop");
            Console.WriteLine("-----------------------");

        }
    }
}
