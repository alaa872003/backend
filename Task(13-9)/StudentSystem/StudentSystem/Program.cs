using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
      
        ApplicationDbContext db=new ApplicationDbContext();
            Console.WriteLine("1)Enter new student");
            Console.WriteLine("2)Enter new course");
            int c= int.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    
                    Student student = new Student();
                    Console.WriteLine("Enter Student Information:");
                    Console.WriteLine($"Name of Student: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Your id:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter phone number: ");
                    string phone = Console.ReadLine();
                    student.Name = name;
                    student.PhoneNumber = phone;
                    student.RegisteredOn = DateTime.Now;
                    db.Students.Add(student);
                    break;
                 case 2:
                    Course course = new Course();
                    Console.WriteLine("Enter course Information:");
                    Console.WriteLine($"Course Name: ");
                    string courseName = Console.ReadLine();
                    Console.WriteLine("Course Id:");
                    int courseId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Description of course: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Start date: ");
                    string startTime = Console.ReadLine();
                    Console.WriteLine("End date: ");
                    string endTime = Console.ReadLine();
                    Console.WriteLine("Course Price: ");
                    int price= int.Parse(Console.ReadLine());

                    course.Name = courseName;
                    course.CourseId = courseId;
                    course.Description = description;
                    course.StartTime= startTime;
                    course.EndTime = endTime;
                    course.Price = price;
                    
                    db.Courses.Add(course);

                    break;
            }
            db.SaveChanges();
        }
    }
}
