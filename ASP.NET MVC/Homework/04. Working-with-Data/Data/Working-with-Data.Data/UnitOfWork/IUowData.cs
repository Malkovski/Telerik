namespace Working_with_Data.Data.UnitOfWork
{
    using Models;
    using Repositories;
    using System;

    public interface IUowData : IDisposable
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
