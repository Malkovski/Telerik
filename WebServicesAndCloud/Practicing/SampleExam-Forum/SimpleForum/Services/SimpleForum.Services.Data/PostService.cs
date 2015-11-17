namespace SimpleForum.Services.Data
{
    using SimpleForum.Data;
using SimpleForum.GlobalConstants;
using SimpleForum.Models;
using SimpleForum.Services.Data.Contracts;
using System;
using System.Linq;

    public class PostService : IPostService
    {
        private IRepository<Post> posts;

        public PostService(IRepository<Post> postRepo)
        {
            this.posts = postRepo;
        }

        public IQueryable<Post> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.posts.All()
                .OrderByDescending(x => x.PostDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int Add(string content, string userId)
        {
            var newPost = new Post
            {
                Content = content,
                UserId = userId,
                PostDate = DateTime.UtcNow,
                Rating = 0
            };

            this.posts.Add(newPost);
            this.posts.SaveChanges();

            return newPost.Id;
        }
    }
}