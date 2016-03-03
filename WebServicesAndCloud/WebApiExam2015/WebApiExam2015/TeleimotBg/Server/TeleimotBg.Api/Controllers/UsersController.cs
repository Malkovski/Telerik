namespace TeleimotBg.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using TeleimotBg.Api.Models.TemplateModels;
    using TeleimotBg.Services.Data.Contracts;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        //---------------GET---------------     
        public IHttpActionResult GetByUsername(string username)
        {
            var result = this.users.GetByUsername(username);

            return this.Ok(result);
        }

        //---------------PUT--------------
        [Authorize]
        [Route("rate")]
        public IHttpActionResult Put(RateSaveModel model)
        {
            var userExists = this.users.All().Any(x => x.Id == model.UserId);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!userExists)
            {
                return this.NotFound();
            }

            this.users.Rate(model.Value, model.UserId);

            return this.Ok();
        }
    }
}
