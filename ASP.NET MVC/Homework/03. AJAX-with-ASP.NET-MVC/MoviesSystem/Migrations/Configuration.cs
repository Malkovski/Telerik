namespace MoviesSystem.Migrations
{
    using Models;
    using System.Linq;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }
            else
            {
                this.SeedMovies(context);
            }

        }

        private void SeedMovies(MoviesDbContext context)
        {

            context.Movies.Add(new Movie()
            {
                Title = "Wolverine",
                Director = "James Mangold",
                Year = "2013",
                Studio = "SomeStudio",
                StudioAddress = "California",
                LeadingMaleRole = new Actor() { Name = "Hugh Jackman", Age = 40 },
                LeadingFemaleRole = new Actor() { Name = "Tao Okamoto", Age = 30 }
            });

            context.Movies.Add(new Movie()
            {
                Title = "The Martian",
                Director = "Anyone",
                Year = "2015",
                Studio = "SomeOtehrStudio",
                StudioAddress = "LA-California",
                LeadingMaleRole = new Actor() { Name = "Matt Damon", Age = 39 },
                LeadingFemaleRole = new Actor() { Name = "Nice woman", Age = 30 }
            });

            context.Movies.Add(new Movie()
            {
                Title = "Desperado",
                Director = "Cool guy",
                Year = "2000",
                Studio = "SomeCoolStudio",
                StudioAddress = "LA-California",
                LeadingMaleRole = new Actor() { Name = "Antonio Banderas", Age = 50 },
                LeadingFemaleRole = new Actor() { Name = "Salma Hayek", Age = 30 }
            });
        }
    }
}
