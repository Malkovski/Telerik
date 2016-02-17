namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> All();

        IQueryable<Joke> All(int page);

        IQueryable<Joke> GetRandomJokes(int count);

        int GetCount();

        Joke GetById(int id);

        int Create(string content, int categoryId);

        int Update(int id, int categoryId, string content);

        void Delete(int id);
    }
}
