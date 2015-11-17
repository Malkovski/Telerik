namespace SimpleForum.Services.Data.Contracts
{
    using SimpleForum.GlobalConstants;
    using SimpleForum.Models;
    using System;
    using System.Linq;

    public interface IPostService
    {
        IQueryable<Post> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize);

        IQueryable<Post> GetPostById(int id);

        int Add(string title, int threadId, string userId);

        int Vote(int postId);

        int AddComment(int id, string text);
    }
}
