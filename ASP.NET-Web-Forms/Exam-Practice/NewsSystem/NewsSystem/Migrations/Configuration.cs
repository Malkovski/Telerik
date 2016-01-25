namespace NewsSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Models.NewsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystem.Models.NewsDbContext context)
        {
            if (!context.Categories.Any())
            {
                var seeder = new SeedData();

                context.Categories.AddOrUpdate(x => x.Name, seeder.Categories.ToArray());
                context.SaveChanges();

                context.Articles.AddOrUpdate(x => x.Title, seeder.Articles.ToArray());
                context.SaveChanges();
            }
        }
    }
}
