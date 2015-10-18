namespace StudentsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentsSystem.Data;
    using StudentsSystem.Models;
    using StudentsSystem.Data.Migrations;
    using System.Data.Entity;
    using StudentsSystem.Data.Repositories;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, Configuration>());

            //IStudentsSystemDbContext db = new StudentsSystemDbContext();

            //var testStudent = new Student
            //{
            //    Name = "First test student",
            //    Number = "00001"
            //};

            //db.Students.Add(testStudent);
            //db.SaveChanges();

            //Console.WriteLine(db.Students.Count());

            var homeworkRepo = new EfRepository<Homework>();
            var time = DateTime.Now;
     

            homeworkRepo.Add(new Homework
            {
                Content = "EfRepository working test",
                TimeSent = string.Format("{0}", time)
            });

            homeworkRepo.SaveChanges();
        }

    }
}