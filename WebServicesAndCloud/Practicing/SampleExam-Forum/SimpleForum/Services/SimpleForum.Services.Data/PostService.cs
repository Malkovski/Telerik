namespace SimpleForum.Services.Data
{
    using System;
    using System.Linq;
    using SimpleForum.Data;
    using SimpleForum.GlobalConstants;
    using SimpleForum.Models;
    using SimpleForum.Services.Data.Contracts;

    public class PostService : IPostService
    {
        private readonly IRepository<Post> posts;

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

        public IQueryable<Post> GetPostById(int id)
        {
            return this.posts.All()
                .Where(x => x.Id == id);
        }

        public int Add(string content, int threadId, string userId)
        {
            var newPost = new Post
            {
                Content = content,
                UserId = userId,
                ThreadId = threadId,
                PostDate = DateTime.UtcNow,
                Rating = 0
            };

            this.posts.Add(newPost);
            this.posts.SaveChanges();

            return newPost.Id;
        }

        public int Vote(int id)
        {
            var currentPost = this.GetPostById(id).FirstOrDefault();

            currentPost.Rating += 1;

            this.posts.SaveChanges();

            return currentPost.Id;
        }


        public int AddComment(int id, string text)
        {
            var currentPost = this.GetPostById(id).FirstOrDefault();

            var newComment = new Comment
            {
                Text = text,
                PostId = id
            };

            currentPost.Comments.Add(newComment);

            this.posts.SaveChanges();

            return newComment.Id;
        }
    }
}