namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using Common;
    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<JokeCategory> categories;

        public CategoriesService(IDbRepository<JokeCategory> categories)
        {
            this.categories = categories;
        }

        public JokeCategory EnsureCategory(string name)
        {
            var category = this.categories.All().FirstOrDefault(x => x.Name == name);
            if (category != null)
            {
                return category;
            }

            category = new JokeCategory { Name = name };
            this.categories.Add(category);
            this.categories.Save();
            return category;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }

        public IQueryable<JokeCategory> All(int page)
        {
            var allJokesCount = this.categories.All().Count();
            var totalPages = Math.Ceiling(allJokesCount / (decimal)GlobalConstants.ItemsPerPage);
            var itemsToSkip = (page - 1) * GlobalConstants.ItemsPerPage;

            var result = this.categories.All().Where(x => x.IsDeleted == false).Skip(itemsToSkip).Take(GlobalConstants.ItemsPerPage);

            return result;
        }

        public string[] GetNames()
        {
            return this.categories.All().Where(x => x.IsDeleted == false).Select(x => x.Name).ToArray();
        }
    }
}
