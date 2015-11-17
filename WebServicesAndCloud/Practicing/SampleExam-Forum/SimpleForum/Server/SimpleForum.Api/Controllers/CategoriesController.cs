namespace SimpleForum.Api.Controllers
{
    using SimpleForum.Api.Models.TemplateModels;
    using SimpleForum.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;

    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categories = categoryService;
        }

        public IHttpActionResult Get()
        {
            var result = this.categories
                .All(1, int.MaxValue)
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}
