namespace SimpleForum.Api.Controllers
{
    using SimpleForum.Api.Models.TemplateModels;
    using SimpleForum.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        private readonly IPostService posts;

        public PostsController(IPostService postService)
        {
            this.posts = postService;
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            var result = this.posts
                .All(page: 1, pageSize: int.MaxValue)
                .ProjectTo<PostResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetByPages(string page, string count)
        {
            var p = int.Parse(page);
            var c = int.Parse(count);

            var result = this.posts
                .All(p, c)
                .OrderByDescending(x => x.PostDate)
                .ProjectTo<PostResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetByThreadId(int id)
        {
            var result = this.posts
                .All(page: 1, pageSize: int.MaxValue)
                .Where(x => x.ThreadId == id)
                .ProjectTo<PostResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        [Route("{id}/create")]
        [HttpPost]
        public IHttpActionResult Create(int id, PostSaveDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newPostId = this.posts.Add(model.Content, id, this.User.Identity.GetUserId());

            return this.Ok(string.Format("New post with id {0} created", newPostId));
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/vote")]
        public IHttpActionResult Vote(int id)
        {
            var vodedFor = this.posts.Vote(id);

            return this.Ok(string.Format("Voted for post with id {0}", vodedFor));
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/comment")]
        public IHttpActionResult Comment(int id, CommentSaveModel model)
        {
            var comented = this.posts.AddComment(id, model.Text);

            return this.Ok(string.Format("Commented post with id {0}", comented));
        }
    }
}
