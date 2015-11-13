namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categories = categoryRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories.All().Where(x => x.Id == id);
        }

        public int Add(string name)
        {
            var newCategory = new Category
            {
                Name = name
            };

            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory.Id;
        }
    }
}
