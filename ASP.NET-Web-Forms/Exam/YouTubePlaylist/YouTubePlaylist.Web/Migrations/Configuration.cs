namespace YouTubePlaylist.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YouTubePlaylist.Web.Models;
    using YouTubePlaylist.Web.RandomDataGenerator;

    internal sealed class Configuration : DbMigrationsConfiguration<YouTubePlaylist.Web.Models.YoutubeDbContext>
    {
        private IRandomDataGenerator random = RandomDataGenerator.Instance;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(YoutubeDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            this.SeedCategories(context, 31);
            this.SeedPlaylists(context, 11);
            //this.SeedUsers(context);
        
        }

        private void SeedUsers(YoutubeDbContext context)
        {
            context.Users.Add(new User { Email = "user1@site.com" });
            context.Users.Add(new User { Email = "user2@site.com" });
            context.Users.Add(new User { Email = "user3@site.com" });
            context.Users.Add(new User { Email = "user4@site.com" });
            context.Users.Add(new User { Email = "user5@site.com" });

            context.SaveChanges();
        }

        private void SeedCategories(YoutubeDbContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var category = new Category
                {
                    Name = this.random.GetRandomStringWithRandomLength(5, 15)
                };

                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private void SeedPlaylists(YoutubeDbContext context, int count)
        {
            var current = context.Categories.First();
            User user = new User() { UserName = "AnonymousTesterMaster", Email = "admin@admin.admin", FirstName = "Mastah", LastName = "Fumastah"};
            for (int i = 0; i < count; i++)
            {
                var playlists = new Playlist
                {
                    Title = this.random.GetRandomStringWithRandomLength(5, 15),
                    CreationDate = DateTime.UtcNow,
                    Description = this.random.GetRandomStringWithRandomLength(20, 200),
                    Creator = user,
                    Category = current
                };

                context.Playlists.Add(playlists);
            }

            context.SaveChanges();
        }
    }
}
