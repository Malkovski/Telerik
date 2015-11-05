namespace SourceControlSystem.Data
{
    using System.Data.Entity;
    using SourceControlSystem.Models;
    using System.Data.Entity.Infrastructure;

    public interface ISourceControlSystemDbContext
    {
        IDbSet<Commit> Commits { get; set; }

        IDbSet<SoftwareProject> SoftwareProjects { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}