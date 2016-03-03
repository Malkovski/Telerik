namespace TeleimotBg.Services.Data.Contracts
{
    using System.Linq;

    using TeleimotBg.Models;

    public interface IUserService
    {
        IQueryable<User> All();

        object GetByUsername(string username);

        void Rate(int value, string userId);
    }
}
