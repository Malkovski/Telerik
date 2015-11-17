namespace SimpleForum.Services.Data.Contracts
{
    using SimpleForum.GlobalConstants;
    using SimpleForum.Models;
    using System;
    using System.Linq;

    public interface ICategoryService
    {
        IQueryable<Category> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        int Add(string name);
    }
}
