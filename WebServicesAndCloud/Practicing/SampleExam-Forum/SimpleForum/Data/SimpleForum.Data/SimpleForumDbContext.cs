namespace SimpleForum.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SimpleForum.Models;

    public class SimpleForumDbContext : IdentityDbContext<User>, ISimpleForumDbContext
    {
        public SimpleForumDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Replace model with real one!!!!!!!
        public IDbSet<Thread> Threads { get; set; }

        // Replace model with real one!!!!!!!
        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public static SimpleForumDbContext Create()
        {
            return new SimpleForumDbContext();
        }
    }
}