namespace TeleimotBg.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using AutoMapper.QueryableExtensions;

    using TeleimotBg.Api.Models.TemplateModels;
    using TeleimotBg.GlobalConstants;
    using TeleimotBg.Services.Data.Contracts;

    [EnableCors("*", "*", "*")]
    [Authorize]
    public class CommentsController : ApiController
    {
        private readonly ICommentService comments;

        public CommentsController(ICommentService comments)
        {
            this.comments = comments;
        }

        //-------------GET------------------
        public IHttpActionResult Get(int id, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            var result = this.comments
                .All(id, skip, take)
                .ProjectTo<CommentsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetByUsername(string username, int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            var result = this.comments
                .GetCommentsByUsername(username, skip, take)
                .ProjectTo<CommentsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        //-------------POST-----------------
        public IHttpActionResult Post(CommentSaveToDbModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdCommentID = this.comments.Add(model.RealEstateId, model.Content);

            var result = this.comments
                .GetCommentById(createdCommentID)
                .ProjectTo<CommentsResponseModel>()
                .FirstOrDefault();

            return this.Created(string.Empty, result);
        }
    }
}
