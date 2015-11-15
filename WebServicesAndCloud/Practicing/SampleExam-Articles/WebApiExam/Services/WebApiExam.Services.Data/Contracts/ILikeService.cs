namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using WebApiExam.Models;

    public interface ILikeService
    {
        IQueryable<Like> All();

        IQueryable<Like> GetById(int id);

        int Add(int articleId);

        void Remove(int articleId);
    }
}
