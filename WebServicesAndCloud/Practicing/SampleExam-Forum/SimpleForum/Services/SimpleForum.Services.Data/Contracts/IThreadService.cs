namespace SimpleForum.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using SimpleForum.GlobalConstants;
    using SimpleForum.Models;

    public interface IThreadService
    {
        IQueryable<Thread> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        int Add(string title, string content, string catgory, string userId);

        int AddCategory(int id, string category);
    }
}