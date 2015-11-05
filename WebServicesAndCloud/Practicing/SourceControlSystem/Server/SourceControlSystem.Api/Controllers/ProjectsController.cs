namespace SourceControlSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models.Projects;
    using Constants.UtilityConstants;
    using SourceControlSystem.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using System.Web.Http.Cors;
    using SourceControlSystem.Api.Infrastucture;

    public class ProjectsController : ApiController
    {
        private readonly IProjectsServices projects;

        public ProjectsController(IProjectsServices projectServices)
        {
            this.projects = projectServices;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            //Getting instanve if needed!!!!!!!!!!!
           // ObjectFactory.Get<IProjectsServices>();

            var result = this.projects
                .All(page: 1)
                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
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

            var result = this.projects.All()
                                .Where(pr => pr.Name == id && (!pr.Private || (pr.Private && pr.Users.Any(c => c.UserName == this.User.Identity.Name))))
                                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = UtilityConstants.PageSize)
        {
            var result = this.projects
                .All(page, pageSize)
                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveProjectRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.projects.Add(model.Name, model.Description, this.User.Identity.Name, model.Private);

            return this.Ok(createdProjectId);
        }
    }
}