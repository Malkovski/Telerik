namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using WebApiExam.Api.Infrastructure.ObjectFactory;
    using WebApiExam.Api.Models.TemplateModels;
    using WebApiExam.Data;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    [Authorize]
    public class CommentsController : ApiController
    {
        private readonly ICommentService comment;

        public CommentsController(ICommentService commentService)
        {
            this.comment = commentService;
        }

        //POST:api/articles/id/comments -> adds new commentt to article
        //[Route("api/articles/id/comments")]
        [HttpPost]
        public IHttpActionResult Post(int id, CommentSaveToDbRequestModel model)
        {
            var currentArticles = ObjectFactory.Get<IRepository<Article>>();

            if (!currentArticles.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdCommentId = comment.Add(model.Content, this.User.Identity.Name, id);

            return this.Ok(createdCommentId);
        }
    }
}