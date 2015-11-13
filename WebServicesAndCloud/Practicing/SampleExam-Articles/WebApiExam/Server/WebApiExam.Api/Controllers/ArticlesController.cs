namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using WebApiExam.Api.Infrastructure.ObjectFactory;
    using WebApiExam.Api.Models.TemplateModels;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;

    [EnableCors("*", "*", "*")]
    [Authorize]
    public class ArticlesController : ApiController
    {
        private readonly IArticleService article;

        public ArticlesController(IArticleService articleService)
        {
            this.article = articleService;
        }

        //GET:api/articles/ -> Gets top 10 articles, sorted by their date of creation
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            //Getting instance if needed!!!!!!!!!!!
            //ObjectFactory.Get<ITemplateService>();

            var result = this.article
                .All()
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Article id cannot be null or empty!");
            }

            var current = int.Parse(id);

            var result = this.article.All()
                                .Where(a => a.Id == current)
                                .Select(ArticleWithCommentsResponseModel.FromGameWithDetails)
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult GetByCategoryName(string categoryName)
        {
            var parms = this.RequestContext.Url.ToString(); 

            if (string.IsNullOrEmpty(categoryName))
            {
                return this.BadRequest("Article id cannot be null or empty!");
            }

            

            var result = this.article.All()
                                .Where(a => a.Category == categoryName)
                                .ProjectTo<ArticleResponseModel>()
                                .ToList();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        //[Route("api/projects/all")]
        //GET: api/articles?page=P -> Gets the articles at positions from P*10 to (P+1)*10. The articles sorted by date of creation and are at most 10.
        [AllowAnonymous]
        public IHttpActionResult Get(int page, int pageSize = UtilityConstants.DefaultPageSize)
        {
            var result = this.article
                .All(page, pageSize)
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        //POST:api/articles -> Creates a new thread, returns the article created so it can be loaded in the UI
        //[HttpPost]
        public IHttpActionResult Post(ArticleSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdArticle = this.article.Add(model.Title, model.Content, model.Category, model.Tags);

            var result = this.article
                .All()
                .Where(a => a.Id == createdArticle)
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        //POST:api/articles/id/comments -> adds new commentt to article
        [Route("api/articles/id/comments")]
        [HttpPost]
        public IHttpActionResult PostComment(int id, string comment, CommentSaveToDbRequestModel model)
        {
            var comments = ObjectFactory.Get<ICommentService>();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdComment = comments.Add(model.Content, this.User.Identity.Name, id);

            return this.Ok(createdComment);
        }
    }
}