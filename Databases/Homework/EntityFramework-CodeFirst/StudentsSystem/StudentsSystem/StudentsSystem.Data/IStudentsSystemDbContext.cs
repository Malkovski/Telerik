namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Models;
    using System.Data.Entity.Infrastructure;

    public interface IStudentsSystemDbContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}