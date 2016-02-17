namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Models;

    public interface ILikesService
    {
        IQueryable<Like> All();

        Like GetById(int id);

        Like GetByUserAndJoke(string userId, int jokeId);

        int GetAllLikes(int jokeId);

        int Create(string userId, int jokeId, int likeType);

        int Update(string userId, int jokeId, int likeType);

        void Delete(int id);
    }
}
