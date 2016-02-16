namespace Working_with_Data.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TweetsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TweetsDbContext context)
        {
            //this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedTweets(context);
        }

        private void SeedUsers(TweetsDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName =  "DefaultUser"};

            manager.Create(user, "123456");
           // manager.AddToRole(user.Id, "Admin");

            context.SaveChanges();
        }

        private void SeedTweets(TweetsDbContext context)
        {
            var user = context.Users.FirstOrDefault();

            for (int i = 0; i < 15; i++)
            {
                var newTweet = new Tweet
                {
                    Content = "seeded tweet " + i,
                    CreatedOn = DateTime.Now.AddMinutes(-i),
                    UserId = user.Id
                };

                context.Tweets.Add(newTweet);
            }

            context.SaveChanges();
        }

        //private void SeedRoles(TweetsDbContext context)
        //{
        //    if (context.Roles.Any())
        //    {
        //        return;
        //    }

        //    context.Roles.Add(new IdentityRole { Name = "Admin" });
        //    context.SaveChanges();
        //}
    }
}
