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
    public class TemplateController : ApiController
    {
        private readonly ITemplateService template;

        public TemplateController(ITemplateService templateService)
        {
            this.template = templateService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            //Getting instance if needed!!!!!!!!!!!
            //ObjectFactory.Get<ITemplateService>();

            var result = this.template
                .All(page: 1)
                .ProjectTo<TemplateResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Project id cannot be null or empty!");
            }

            var result = this.template.All()
                                .Where(a => a.Id == 0)
                                .ProjectTo<TemplateResponseModel>()
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = UtilityConstants.DefaultPageSize)
        {
            var result = this.template
                .All(page, pageSize)
                .ProjectTo<TemplateResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(TemplateSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

           // var createdProjectId = this.projects.Add(model.Name, model.Description, this.User.Identity.Name, model.Private);

            return this.Ok(); //(createdProjectId);
        }
    }
}