namespace TeleimotBg.Services.Data
{
    using TeleimotBg.Data;
    using TeleimotBg.Models;
    using TeleimotBg.Services.Data.Contracts;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;

    public class UserService : IUserService
    {
        private IRepository<User> users;
        private IRepository<Comment> comments;
        private IRepository<RealEstate> estates;

        public UserService(IRepository<User> userRepo, IRepository<Comment> comments, IRepository<RealEstate> estates)
        {
            this.users = userRepo;
            this.comments = comments;
            this.estates = estates;
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }

        public void Rate(int value, string userId)
        {
            var currentUser = this.users
                .GetById(userId);

            currentUser.RatesCount++;
            currentUser.Rank += value;

            this.users.SaveChanges();
        }

        public object GetByUsername(string username)
        {
            var commentCount = this.comments.All().Where(x => x.User.UserName == username).Count();
            var estatesCount = this.estates.All().Where(x => x.User.UserName == username).Count();
            var currentuser = this.users.All().Where(x => x.UserName == username).FirstOrDefault();

            double result = this.CalculateRating(currentuser);

            return new
            {
                UserName = username,
                RealEsates = estatesCount,
                Comments = commentCount,
                Rating = result
            };
        }

        private double CalculateRating(User user)
        {
            double rank = user.Rank;
            double count = user.RatesCount;
            double result = rank / count;

            return result;
        }
    }
}
