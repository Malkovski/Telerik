namespace BullsAndCows.Services.Data
{
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Data.Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        private IRepository<User> users;

        public UserService(IRepository<User> userRepo)
        {
            this.users = userRepo;
        }

        public IQueryable<User> All()
        {
            return this.users.All()
                .OrderByDescending(x => x.Rank)
                .Take(10);
        }
    }
}
