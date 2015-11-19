namespace BullsAndCows.Api.Controllers
{
    using BullsAndCows.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using BullsAndCows.Api.Models.TemplateModels;

    public class ScoresController : ApiController
    {
        private readonly IUserService users;

        public ScoresController(IUserService userService)
        {
            this.users = userService;
        }

        public IHttpActionResult Get()
        {
            var result = this.users.All()
                .ProjectTo<HighScoreResponseModel>()
                .ToList();
              

            return this.Ok(result);
        }
    }
}
