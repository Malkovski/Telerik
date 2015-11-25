namespace BullsAndCows.Server.Wcf
{
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public abstract class BaseService
    {
        protected BaseService()
        {
            var db = new ApplicationDbContext();
            this.Users = new EfGenericRepository<User>(db);
        }

        protected IRepository<User> Users { get; private set; }
    }
}