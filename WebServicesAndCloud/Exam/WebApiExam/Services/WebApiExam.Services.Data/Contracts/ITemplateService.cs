namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;

    public interface ITemplateService
    {
        IQueryable<Model1> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        int Add(string name, string description, string creator, bool isPrivate = false);
    }
}