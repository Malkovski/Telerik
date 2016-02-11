namespace Working_with_Data.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using System.Data.Entity;
    using Working_with_Data.Models;

    public class TweetsDbContext : IdentityDbContext<ApplicationUser>
    {
        public TweetsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TweetsDbContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public static TweetsDbContext Create()
        {
            return new TweetsDbContext();
        }

        public System.Data.Entity.DbSet<Working_with_Data.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
