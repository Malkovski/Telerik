namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Models;

    public class StudentsSystemDbContext : DbContext, IStudentsSystemDbContext
    {
        public StudentsSystemDbContext() : base("StudentsSystemDatabase")
        {
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}