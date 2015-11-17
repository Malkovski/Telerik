namespace SimpleForum.Services.Data
{
    using SimpleForum.Data;
    using SimpleForum.GlobalConstants;
    using SimpleForum.Models;
    using SimpleForum.Services.Data.Contracts;
    using System;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categories = categoryRepo;
        }

        public IQueryable<Category> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.categories
                .All()
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int Add(string name)
        {
            var newCat = new Category
            {
                Name = name
            };

            this.categories.Add(newCat);
            this.categories.SaveChanges();

            return newCat.Id;
        }
    }
}
