namespace TeleimotBg.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using TeleimotBg.Models;

    public interface ITeleimotDbContext
    {
        // Replace model with real one!!!!!!!
        IDbSet<RealEstate> RealEstates { get; set; }

        // Replace model with real one!!!!!!!
        IDbSet<Comment> Comments { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}