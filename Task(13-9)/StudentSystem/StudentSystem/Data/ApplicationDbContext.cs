using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Student>Students { get; set; }
        public DbSet<Course> Courses { get; set; }  
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LENOVO;Initial Catalog=StudentSystem;Integrated Security=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(100).IsUnicode().IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.PhoneNumber).HasMaxLength(10).IsFixedLength().IsUnicode(false).IsRequired(false);
            modelBuilder.Entity<Student>().Property(e => e.RegisteredOn).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.Birthday).IsRequired(false);
           
           

            modelBuilder.Entity<Course>().Property(e => e.Name).HasMaxLength(80).IsUnicode().IsRequired();
            modelBuilder.Entity<Course>().Property(e => e.Description).IsUnicode().IsRequired(false);
            modelBuilder.Entity<Course>().Property(e => e.StartTime).IsRequired();
            modelBuilder.Entity<Course>().Property(e => e.EndTime).IsRequired();
            modelBuilder.Entity<Course>().Property(e => e.Price).IsRequired();
           
           

            modelBuilder.Entity<Resource>().Property(e => e.Name).HasMaxLength(50).IsUnicode().IsRequired();
            modelBuilder.Entity<Resource>().Property(e => e.URL).IsUnicode(false).IsRequired();
            modelBuilder.Entity<Resource>().Property(e => e.ResourceType).HasConversion<int>().IsRequired();
            modelBuilder.Entity<Resource>().Property(e => e.CourseId).IsRequired();
           
           

            modelBuilder.Entity<HomeWork>().Property(e => e.Content).IsUnicode(false).IsRequired();
            modelBuilder.Entity<HomeWork>().Property(e => e.ContentType).HasConversion<int>().IsRequired();
            modelBuilder.Entity<HomeWork>().Property(e => e.SubmissionTime).IsRequired();
            modelBuilder.Entity<HomeWork>().Property(e => e.StudentId).IsRequired();




            modelBuilder.Entity<Student>().HasData(
               new Student { StudentId = 1, Name = "Ali", PhoneNumber = "0111111111", RegisteredOn = DateTime.Now },
               new Student { StudentId = 2, Name = "Alaa", PhoneNumber = "0111111111", RegisteredOn = DateTime.Now.AddHours(1) },
               new Student { StudentId = 3, Name = "Ola", PhoneNumber = "0111111111", RegisteredOn = DateTime.Now.AddHours(2) });

            modelBuilder.Entity<Course>().HasData(
               new Course { CourseId = 1, Name = "Math",Description = "good", StartTime = "1/1/2023", EndTime = "1/3/2023", Price = 2000 },
               new Course { CourseId = 2, Name = "OOP", Description = "nice", StartTime = "1/1/2023", EndTime = "1/3/2023", Price = 2000 },
               new Course { CourseId = 3, Name = "DSP", Description = "perfect", StartTime = "1/1/2023", EndTime = "1/3/2023", Price = 2000 });


            modelBuilder.Entity<HomeWork>().HasData(
                new HomeWork { HomeWorkId = 1, Content = "abc",ContentType = ContentTypes.PDF , SubmissionTime =DateTime.Now, StudentId = 2 },
                new HomeWork { HomeWorkId = 2, Content = "abc", ContentType = ContentTypes.ZIP, SubmissionTime = DateTime.Now.AddDays(1), StudentId = 1},
                new HomeWork{ HomeWorkId = 3, Content = "abc", ContentType = ContentTypes.Application, SubmissionTime = DateTime.Now.AddHours(1), StudentId = 3 });



            modelBuilder.Entity<Resource>().HasData(
               new Resource { ResourceId = 1, Name = "abc", URL = "def", ResourceType = ResourceTypes.Video, CourseId = 1 },
               new Resource { ResourceId = 2, Name = "abc", URL = "def", ResourceType = ResourceTypes.Document, CourseId = 2 },
               new Resource { ResourceId = 3, Name = "abc", URL = "def", ResourceType = ResourceTypes.Presentation, CourseId = 3 });
            
        }


    }
}
