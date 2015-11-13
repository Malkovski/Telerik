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

            var result = this.article.GetById(current)
                                .ProjectTo<ArticleWithCommentsResponseModel>()
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        //GET:api/articles?category=[categoryName] -> Gets top 10 articles in category “categoryName”,sorted by their date of creation
        public IHttpActionResult GetByCategoryName(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return this.BadRequest("Article id cannot be null or empty!");
            }

            var result = this.article.All(page:1, pageSize: int.MaxValue - 1)
                                .Where(a => a.Category.Name == category)
                                .OrderByDescending(x => x.CreatedOn)
                                .Take(10)
                                .ProjectTo<ArticleResponseModel>()
                                .ToList();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult GetInRangeByCategoryName(string category, string page)
        {
            if (string.IsNullOrEmpty(category))
            {
                return this.BadRequest("Article category cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(page))
            {
                return this.BadRequest("Article page cannot be null or empty!");
            }

            var pages = int.Parse(page);

            var result = this.article.All(page: 1, pageSize: int.MaxValue - 1)
                                .Where(a => a.Category.Name == category)
                                .OrderByDescending(x => x.CreatedOn)
                                .AsQueryable()
                                .Skip(pages * 10)
                                .Take(10)
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
        [HttpPost]
        public IHttpActionResult Post(ArticleSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdArticle = this.article.Add(model.Title, model.Content, model.Category, model.Tags);

            var result = this.article
                .GetById(createdArticle)
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(result);
        }

       
    }
}