namespace BullsAndCows.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using BullsAndCows.Api.Models.TemplateModels;
    using BullsAndCows.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.Models;

    [EnableCors("*", "*", "*")]
    public class GamesController : ApiController
    {
        private readonly IGameService games;

        public GamesController(IGameService gameService)
        {
            this.games = gameService;
        }

        public IHttpActionResult Get()
        {
            return this.DefaultGet();
        }

        public IHttpActionResult Get(string page)
        {
            return this.DefaultGet(page);
        }

        public IHttpActionResult DefaultGet(string p =  null)
        {
            //Validate!!
            int pageInt;
            if (string.IsNullOrEmpty(p))
            {
                pageInt = 1;
            }
            else
            {
                pageInt = int.Parse(p);
            }

            var isAuthorized = this.User.Identity.IsAuthenticated;
            var current = this.User.Identity.GetUserId();

            if (!isAuthorized)
            {
                var result = this.games
                    .All(page: 1)
                .ProjectTo<CreatedGameResponseModel>()
                .ToList();

                return this.Ok(result);
            }
            else
            {
                var result = this.games
                    .All(pageInt)
                    .Where(x => (x.BlueUserId == current || 
                        x.RedUserId == current && (x.GameState != GameState.Finished)) ||
                        x.GameState == GameState.WaitingForOpponent)
                    .OrderBy(x => x.GameState)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.DateCreated)
                    .ThenBy(x => x.RedUser.UserName)
                    .ProjectTo<CreatedGameResponseModel>()
                    .ToList();

                return this.Ok(result);
            }  
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.games.UserIsPartOfGame(id, userId))
            {
                return this.BadRequest("You dont belong here!");
            }

            var result = this.games.GetGameById(id)
                                .ProjectTo<DetailedGameResponseModel>(new { userId })
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        //--------------------POST--------------------------
        [Authorize]
        public IHttpActionResult Post(GameSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

           var createdGameId = this.games.Add(model.Name, model.Number, this.User.Identity.GetUserId());

           var result = this.games
               .GetGameById(createdGameId)
               .ProjectTo<CreatedGameResponseModel>()
               .FirstOrDefault();

           return this.Created("", result);
        }

        public IHttpActionResult Put(int id, JoinRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.games.GameIsAvailable(id, userId))
            {
                return this.BadRequest("Shizo?!?");
            }

            var joinedGameName = this.games.JoinGame(id, userId, model.Number);

            return this.Ok(new { result = string.Format("You joined game \"{0}\"", joinedGameName) });
        }
    }
}