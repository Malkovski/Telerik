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
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly IGameService games;
        private readonly IGuessService guesses;

        public GamesController(IGameService gameService, IGuessService guessService)
        {
            this.games = gameService;
            this.guesses = guessService;
        }

        //--------------------GET--------------------------
        public IHttpActionResult Get()
        {
            return this.DefaultGet();
        }

        public IHttpActionResult Get(string page)
        {
            return this.DefaultGet(page);
        }

        [HttpGet]
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
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            //Validate!!
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
        [HttpPost]
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

        [Authorize]
        public IHttpActionResult Play(int id, JoinRequestModel model)
        {
            //VAliedate pls!!!!!!

            var userId = this.User.Identity.GetUserId();
            var gamePlayed = this.games.GetGameById(id).FirstOrDefault(); 

            if (gamePlayed.GameState == GameState.Finished)
            {
                return this.BadRequest("Game has already finished!");
            }

            if (!this.games.CanMakeGuess(gamePlayed, userId))
            {
                return this.BadRequest("Not your turn!");
            }

            var guessId = this.games.MakeGuess(gamePlayed, id, model.Number, userId);

            var result = this.guesses
                .GetById(guessId)
                .ProjectTo<GuessResponseModel>()
                .FirstOrDefault();
                
            return this.Ok(result);
        }

        //--------------------PUT--------------------------
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, JoinRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Enter your number please!");
            }

            if (this.games.GetGameById(id).FirstOrDefault() == null)
            {
                return this.NotFound();
            }

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