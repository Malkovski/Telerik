namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using WebApiExam.Api.Models.TemplateModels;
    using WebApiExam.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;

    public class TagsController : ApiController
    {
        private readonly ITagService tag;

        public TagsController(ITagService tagService)
        {
            this.tag = tagService;
        }

        public IHttpActionResult Get()
        {
            var result = this.tag
                .All()
                .ProjectTo<TagResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetById(string id)
        {
            var currentId = int.Parse(id);

            var result = this.tag.GetById(currentId);

            return this.Ok(result);
        }
    }
}
