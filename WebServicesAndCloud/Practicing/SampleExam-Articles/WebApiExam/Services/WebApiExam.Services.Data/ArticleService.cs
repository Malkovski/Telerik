namespace WebApiExam.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> articles;
        private readonly IRepository<Category> categories;

        public ArticleService(IRepository<Article> articleRepo, IRepository<Category> categoriesRepo)
        {
            this.articles = articleRepo;
            this.categories = categoriesRepo;
        }

        public IQueryable<Article> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.articles
                .All()
                .OrderByDescending(s => s.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        // The logic here can be different ofc - parameters depends ...!!!!!!!! 
        public int Add(string title, string content, string category, ICollection<Tag> tags)
        {
            var newArticle = new Article
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.Now,
                Tags = tags
            };

            var existingCategory = this.categories.All().Where(x => x.Name == category).FirstOrDefault();

            if (existingCategory != null)
            {
                newArticle.CategoryId = existingCategory.Id;
            }
            else
            {
                var newCategory = new Category
                {
                    Name = category
                };

                categories.Add(newCategory);
                //categories.SaveChanges();
            }

            this.articles.Add(newArticle);
            this.articles.SaveChanges();

            return newArticle.Id;
        }

        public IQueryable<Article> GetById(int id)
        {
            return this.articles.All().Where(x => x.Id == id);
        }
    }
}
