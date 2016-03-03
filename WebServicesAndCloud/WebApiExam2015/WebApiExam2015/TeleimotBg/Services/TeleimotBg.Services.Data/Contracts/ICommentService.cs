namespace TeleimotBg.Services.Data.Contracts
{
    using System.Linq;

    using TeleimotBg.GlobalConstants;
    using TeleimotBg.Models;

    public interface ICommentService
    {
        IQueryable<Comment> All(int id, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize);

        IQueryable<Comment> GetCommentById(int id);

        IQueryable<Comment> GetCommentsByUsername(string username, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize);

        int Add(int estateId, string content);
    }
}
