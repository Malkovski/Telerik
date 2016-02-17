namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Models;
    using RandomDataProvider;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private IRandomDataGenerator randomProvider;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.randomProvider = new RandomDataGenerator();

        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (!context.Jokes.Any())
            {
                this.SeedCategoriesAndJokes(context);
            }

        }

        private void SeedCategoriesAndJokes(ApplicationDbContext context)
        {
            for (int i = 1; i < 10; i++)
            {
                var category = new JokeCategory() { Name = this.randomProvider.GetRandomStringWithRandomLength(4, 14) };

                int jokesCount = this.randomProvider.GetRandomNumber(1, 15);
                for (int j = 0; j < jokesCount; j++)
                {
                    var joke = new Joke()
                    {
                        Content = this.randomProvider.GetRandomStringWithRandomLength(50, 150)
                    };

                    category.Jokes.Add(joke);
                }

                context.JokesCategories.Add(category);
            }

            context.SaveChanges();
        }
    }
}
