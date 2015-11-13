namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;

    public interface ICommentService
    {
        IQueryable<Comment> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        int Add(string content, string creator, int articleId);
    }
}
