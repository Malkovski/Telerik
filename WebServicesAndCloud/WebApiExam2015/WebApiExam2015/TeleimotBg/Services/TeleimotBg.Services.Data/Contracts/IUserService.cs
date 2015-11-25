namespace TeleimotBg.Services.Data.Contracts
{
    using TeleimotBg.Models;
    using System;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> All();

        object GetByUsername(string username);

        void Rate(int value, string userId);
    }
}
