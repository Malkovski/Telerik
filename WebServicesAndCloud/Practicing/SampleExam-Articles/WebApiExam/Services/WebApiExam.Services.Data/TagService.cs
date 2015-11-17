namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class TagService : ITagService
    {
        private IRepository<Tag> tags;

        public TagService(IRepository<Tag> tagRepo)
        {
            this.tags = tagRepo;
        }

        public IQueryable<Tag> All()
        {
            return this.tags.All();
        }

        public IQueryable<Tag> GetById(int id)
        {
            return this.tags.All().Where(x => x.Id == id);
        }

        public int Add(string name, int articleId)
        {
            var newTag = new Tag
            {
                Name = name,
                ArticleId = articleId
            };

            this.tags.Add(newTag);
            this.tags.SaveChanges();

            return newTag.Id;
        }
    }
}
