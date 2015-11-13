namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using WebApiExam.Api.Infrastructure.ObjectFactory;
    using WebApiExam.Api.Models.TemplateModels;
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
           // var comments = ObjectFactory.Get<ICommentService>();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdComment = comment.Add(model.Content, this.User.Identity.Name, id);

            return this.Ok(createdComment);
        }
    }
}