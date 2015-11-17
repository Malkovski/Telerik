namespace SimpleForum.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using SimpleForum.Models;

    public interface ISimpleForumDbContext
    {
        // Replace model with real one!!!!!!!
        IDbSet<Thread> Threads { get; set; }

        // Replace model with real one!!!!!!!
        IDbSet<Post> Posts { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}