namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using BullsAndCows.Models;

    public interface IApplicationDbContext
    {
        // Replace model with real one!!!!!!!
        IDbSet<Game> Games { get; set; }

        // Replace model with real one!!!!!!!
        IDbSet<Guess> Guesses { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}