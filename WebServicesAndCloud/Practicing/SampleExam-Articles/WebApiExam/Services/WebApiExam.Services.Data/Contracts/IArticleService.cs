namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;

    public interface IArticleService
    {
        IQueryable<Article> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        int Add(string title, string content, string category, ICollection<Tag> tags);
    }
}