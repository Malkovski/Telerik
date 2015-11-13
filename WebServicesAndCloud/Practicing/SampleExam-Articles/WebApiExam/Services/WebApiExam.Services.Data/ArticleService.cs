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
        private readonly IRepository<User> users;

        public ArticleService(IRepository<Article> model1Repo, IRepository<User> usersRepo)
        {
            this.articles = model1Repo;
            this.users = usersRepo;
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
           // User currentUser = this.users.All().FirstOrDefault(u => u.UserName == creator);

            var newArticle = new Article
            {
                Title = title,
                Content = content,
                Category = category,
                CreatedOn = DateTime.Now,
                Tags = tags
            };

            
            //newProject.Users.Add(currentUser);

            this.articles.Add(newArticle);
            this.articles.SaveChanges();

            return newArticle.Id;
        }
    }
}
