namespace SourceControlSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using SourceControlSystem.Api.Models.Projects;
    using Constants.UtilityConstants;
    using SourceControlSystem.Services.Data.Contracts;
    using SourceControlSystem.Services.Data;

    public class ProjectsController : ApiController
    {
        private readonly IProjectsServices projects;

        public ProjectsController()
        {
            this.projects = new ProjectsServices();
        }

        public IHttpActionResult Get()
        {
            var result = this.projects
                .All(page: 1)
                .Select(SoftwareProjectsDetailsResponseModel.FromModel).ToList();

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
                                .Select(SoftwareProjectsDetailsResponseModel.FromModel)
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
                .Select(SoftwareProjectsDetailsResponseModel.FromModel)
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