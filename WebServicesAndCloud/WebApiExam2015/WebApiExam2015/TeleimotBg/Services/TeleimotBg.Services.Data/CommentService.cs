namespace TeleimotBg.Services.Data
{
    using System;
    using System.Linq;
    using System.Web;

    using TeleimotBg.Data;
    using TeleimotBg.Models;
    using TeleimotBg.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using TeleimotBg.GlobalConstants;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;
        private readonly IRepository<RealEstate> estates;

        public CommentService(IRepository<Comment> commentsRepo, IRepository<RealEstate> estatesRepo)
        {
            this.comments = commentsRepo;
            this.estates = estatesRepo;
        }

        public IQueryable<Comment> All(int id, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            if (take > 100)
            {
                take = 100;
            }

            // Return only the top 10 real estates, after sorting them by date and time of creation in descending order.       
            return this.comments.All()
            .Where(x => x.RealEstateId == id)
            .OrderBy(x => x.CreatedOn)
            .Skip((skip) * take)
            .Take(take);
        }

        public IQueryable<Comment> GetCommentById(int id)
        {
            return this.comments.All().Where(x => x.Id == id);
        }

        public IQueryable<Comment> GetCommentsByUsername(string username, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            if (take > 100)
            {
                take = 100;
            }

            return this.comments.All()
            .Where(x => x.User.UserName == username)
            .OrderBy(x => x.CreatedOn)
            .Skip((skip) * take)
            .Take(take);
        }

        public int Add(int estateId, string content)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();

            var newComment = new Comment
            {
                Content = content,
                CreatedOn = DateTime.UtcNow,
                UserId = currentUserId,
                RealEstateId = estateId
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment.Id;
        }
    }
}
