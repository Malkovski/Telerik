namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Common;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    using MvcTemplate.Web.Infrastructure.Sanitizer;
    using Web;

    public class JokesService : IJokesService
    {
        private readonly IDbRepository<Joke> jokes;
        private readonly IIdentifierProvider identifierProvider;
        private readonly ISanitizer sanitizer;

        public JokesService(IDbRepository<Joke> jokes, IIdentifierProvider identifierProvider, ISanitizer sanitizer)
        {
            this.jokes = jokes;
            this.identifierProvider = identifierProvider;
            this.sanitizer = sanitizer;
        }

        public IQueryable<Joke> All()
        {
            return this.jokes.All().Where(x => x.IsDeleted == false);
        }

        public IQueryable<Joke> All(int page)
        {
            var allJokesCount = this.jokes.All().Count();
            var totalPages = Math.Ceiling(allJokesCount / (decimal)GlobalConstants.ItemsPerPage);
            var itemsToSkip = (page - 1) * GlobalConstants.ItemsPerPage;

            var result = this.jokes
                .All()
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.CreatedOn)
                .Skip(itemsToSkip)
                .Take(GlobalConstants.ItemsPerPage);

            return result;
        }

        public int GetCount()
        {
            return this.All().Count();
        }

        public Joke GetById(int id)
        {
            // var intId = int.Parse(id);
            // var intId = this.identifierProvider.DecodeId(id);
            var joke = this.jokes.GetById(id);
            return joke;
        }

        public IQueryable<Joke> GetRandomJokes(int count)
        {
            return this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public int Create(string content, int categoryId)
        {
            var entity = new Joke
            {
                // Sanitize entry content
                Content = this.sanitizer.Sanitize(content),
                CreatedOn = DateTime.Now,
                CategoryId = categoryId
            };

            this.jokes.Add(entity);
            this.jokes.Save();

            return entity.Id;
        }

        public int Update(int id, int categoryId, string content)
        {
            var jokeToUpdate = this.GetById(id);

            jokeToUpdate.CategoryId = categoryId;
            jokeToUpdate.ModifiedOn = DateTime.Now;

            // Sanitize entry content
            jokeToUpdate.Content = this.sanitizer.Sanitize(content);

            this.jokes.Save();

            return jokeToUpdate.Id;
        }

        public void Delete(int id)
        {
            var jokeToDelete = this.GetById(id);
            this.jokes.Delete(jokeToDelete);
            this.jokes.Save();
        }
    }
}
