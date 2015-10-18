namespace StudentsSystem.Data.Migrations
{
    using StudentsSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentsSystem.Data.StudentsSystemDbContext";
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
            this.SeedInitalData(context);
        }

        private void SeedInitalData(IStudentsSystemDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Courses.AddOrUpdate(c => c.Name, new Course
                {
                    Name = "Seeded test course" + i,
                    Materials = (i * 10) + "Seeded materials"
                });

                context.Students.AddOrUpdate(s => s.Name, new Student
                {
                    Name = "Seeded test student" + i,
                    Number = "N%" + (10000 + i)
                });

                context.Homeworks.AddOrUpdate(h => h.Content, new Homework
                {
                    Content = "Seeded test homework content" + i,
                    TimeSent = string.Format("{0}", DateTime.Now)
                });
            }
        }
    }
}
