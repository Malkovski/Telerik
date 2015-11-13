namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Article> articles;
        private readonly IRepository<User> users;
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> commentRepo, IRepository<Article> model1Repo, IRepository<User> usersRepo)
        {
            this.articles = model1Repo;
            this.users = usersRepo;
            this.comments = commentRepo;
        }

        public IQueryable<Comment> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.comments
                .All()
                .OrderByDescending(s => s.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int Add(string content,  string creator, int articleId)
        {
            User currentUser = this.users.All().FirstOrDefault(u => u.UserName == creator);

            var newComment = new Comment
            {
                Content = content,
                DateCreated = DateTime.Now,
                AuthorName = currentUser.UserName,
            };

            //this.comments.Add(newComment);
            this.articles.All().Where(x => x.Id == articleId).FirstOrDefault().Comments.Add(newComment);
            this.articles.SaveChanges();

            return newComment.Id;
        }
    }
}
