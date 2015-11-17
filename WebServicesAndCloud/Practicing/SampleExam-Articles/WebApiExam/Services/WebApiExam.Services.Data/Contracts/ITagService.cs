namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using WebApiExam.Models;

    public interface ITagService
    {
        IQueryable<Tag> All();

        IQueryable<Tag> GetById(int id);

        int Add(string name, int articleId);
    }
}
