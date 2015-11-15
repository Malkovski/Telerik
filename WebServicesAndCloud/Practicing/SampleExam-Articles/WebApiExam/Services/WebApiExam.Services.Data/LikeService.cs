namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class LikeService : ILikeService
    {
        private IRepository<Like> likes;
        private IRepository<Article> articles;

        public LikeService(IRepository<Like> likeRepo, IRepository<Article> articleRepo)
        {
            this.likes = likeRepo;
            this.articles = articleRepo;
        }

        public IQueryable<Like> All()
        {
            return this.likes.All();
        }

        public IQueryable<Like> GetById(int id)
        {
            return this.likes.All().Where(x => x.Id == id);
        }

        public int Add(int articleId)
        {
            var newLike = new Like
            {
                ArticleId = articleId
            };

            this.likes.Add(newLike);
            this.likes.SaveChanges();

            return newLike.Id;
        }

        public void Remove(int articleId)
        {
            var disliked = this.likes.All()
                .Where(x => x.ArticleId == articleId)
                .ToArray();
                            
            this.likes.Delete(disliked.Last());
            this.likes.SaveChanges();
        }
    }
}
