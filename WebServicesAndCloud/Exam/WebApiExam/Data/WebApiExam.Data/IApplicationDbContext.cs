namespace WebApiExam.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using WebApiExam.Models;

    public interface IApplicationDbContext
    {
        // Replace model with real one!!!!!!!
        IDbSet<Model1> Models1 { get; set; }

        // Replace model with real one!!!!!!!
        IDbSet<Model2> Models2 { get; set; }

        IDbSet<Model3> Models3 { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}