namespace SimpleForum.Api.Controllers
{
    using SimpleForum.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        private IPostService posts;

        public PostsController(IPostService postService)
        {
            this.posts = postService;
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            return this.Ok();
        }


     
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(PostSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            

            return this.Ok();
        }
    }
}
