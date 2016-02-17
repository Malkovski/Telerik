namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class LikesService : ILikesService
    {
        private readonly IDbRepository<Like> likes;

        public LikesService(IDbRepository<Like> likes)
        {
            this.likes = likes;
        }

        public IQueryable<Like> All()
        {
            return this.likes.All();
        }

        public Like GetById(int id)
        {
            return this.likes.GetById(id);
        }

        public Like GetByUserAndJoke(string userId, int jokeId)
        {
            var like = this.All().FirstOrDefault(x => x.UserId == userId && x.JokeId == jokeId);
            return like;
        }

        public int Create(string userId, int jokeId, int likeType)
        {
            var like = new Like
            {
                UserId = userId,
                JokeId = jokeId,
                Type = (LikeType)likeType
            };

            this.likes.Add(like);
            this.likes.Save();

            return like.Id;
        }

        public int Update(string userId, int jokeId, int likeType)
        {
            var like = this.GetByUserAndJoke(userId, jokeId);

            if (like.Type == LikeType.Neutral)
            {
                like.Type = (LikeType)likeType;
            }
            else if (like.Type != LikeType.Neutral && like.Type != (LikeType)likeType)
            {
                like.Type = LikeType.Neutral;
            }

            this.likes.Save();

            return like.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAllLikes(int jokeId)
        {
            return this.likes.All().Where(x => x.JokeId == jokeId).Sum(x => (int)x.Type);
        }
    }
}
