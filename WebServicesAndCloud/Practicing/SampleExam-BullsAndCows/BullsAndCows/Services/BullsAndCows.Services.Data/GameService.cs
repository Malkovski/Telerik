namespace BullsAndCows.Services.Data
{
    using System;
    using System.Linq;
    using BullsAndCows.Data;
    using BullsAndCows.GlobalConstants;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Data.Contracts;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> games;
        private readonly IRepository<User> users;

        public GameService(IRepository<Game> gamesRepo, IRepository<User> usersRepo)
        {
            this.games = gamesRepo;
            this.users = usersRepo;
        }

        public IQueryable<Game> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.games
                .All()
                .OrderBy(x => x.GameState)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.DateCreated)
                .ThenBy(x => x.RedUser.UserName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Game> GetGameById(int id)
        {
            return this.games.All().Where(x => x.Id == id);
        }

        // The logic here can be different ofc - parameters depends ...!!!!!!!!
        public int Add(string name, string number, string creatorId)
        {
            var newGame = new Game
            {
                Name = name,
                RedNumber = number,
                DateCreated = DateTime.UtcNow,
                GameState = GameState.WaitingForOpponent,
                RedUserId = creatorId
            };

            this.games.Add(newGame);
            this.games.SaveChanges();

            return newGame.Id;
        }

        public string JoinGame(int id, string userId, string number)
        {
            var gameToJoin = this.games.GetById(id);
            var rand = RandomGenerator.GetRandomNumber(1, 2);

            gameToJoin.BlueUserId = userId;
            gameToJoin.GameState = (GameState)rand;
            gameToJoin.BlueNumber = number;

            this.games.SaveChanges();

            return gameToJoin.Name;
        }

        public bool GameIsAvailable(int id, string userId)
        {
            return !this.games.All().Any(x => x.Id == id &&
                (x.RedUserId == userId ||
                x.GameState != GameState.WaitingForOpponent));
        }

        public bool UserIsPartOfGame(int id, string userId)
        {
            return this.games.All().Any(x => x.Id == id &&
                (x.RedUserId == userId || x.BlueUserId == userId));
        }
    }
}
