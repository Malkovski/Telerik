namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using WebApiExam.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using WebApiExam.Api.Models.TemplateModels;

    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categories;
        private readonly IArticleService article;

        public CategoriesController(ICategoryService categoryService, IArticleService articleService)
        {
            this.categories = categoryService;
            this.article = articleService;
        }

        public IHttpActionResult Get()
        {
            var result = this.categories
                .All()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Category id cannot be null or empty!");
            }

            var current = int.Parse(id);

            var result = this.article
                .All(page: 1, pageSize: int.MaxValue - 1)
                .Where(x => x.CategoryId == current)
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<ArticleResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}