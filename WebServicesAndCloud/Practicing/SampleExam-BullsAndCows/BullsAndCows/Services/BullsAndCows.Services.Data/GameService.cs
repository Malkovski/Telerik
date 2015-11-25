namespace BullsAndCows.Services.Data
{
    using System;
    using System.Linq;
    using System.Web;
    using BullsAndCows.Data;
    using BullsAndCows.GlobalConstants;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> games;
        private readonly IRepository<User> users;
        private readonly IRepository<Notification> notifications;

        public GameService(IRepository<Game> gamesRepo, IRepository<User> usersRepo, IRepository<Notification> notificationRepo)
        {
            this.games = gamesRepo;
            this.users = usersRepo;
            this.notifications = notificationRepo;
        }

        public IQueryable<Game> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
           var userId = HttpContext.Current.User.Identity.GetUserId();

            return this.games
                .All()
                .Where(x => (x.BlueUserId == userId ||
                        x.RedUserId == userId && (x.GameState != GameState.Finished)) ||
                        x.GameState == GameState.WaitingForOpponent)
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
            var currentUser = this.users.GetById(userId);

            var rand = RandomGenerator.GetRandomNumber(1, 2);

            gameToJoin.BlueUserId = userId;
            gameToJoin.GameState = (GameState)rand;
            gameToJoin.BlueNumber = number;

            var notify = new Notification
            {
                Message = string.Format("{0} joined your game", currentUser.UserName),
                DateCreated = DateTime.UtcNow,
                Type = NotificationType.GameJoined,
                State = State.Unread,
                GameId = id,
                UserId = gameToJoin.RedUserId
            };

            this.notifications.Add(notify);
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

        public bool CanMakeGuess(Game game, string userId)
        {
            if ((game.GameState == GameState.RedInTurn && game.RedUserId == userId) ||
                ((game.GameState == GameState.BlueInTurn) && game.BlueUserId == userId))
            {
                return true;
            }

            return false;
        }

        public int MakeGuess(Game game, int id, string number, string userId)
        {
            var newGuess = new Guess
            {
                Number = number,
                DateMade = DateTime.UtcNow,
                GameId = game.Id,
                UserId = userId
            };

            this.CalculateResult(newGuess, game, number, userId);
            this.ChangeGameState(game, userId, newGuess.BullsCount);

            if (newGuess.BullsCount == 4)
            {
                this.UpdateRanks(game.BlueUserId, game.RedUserId, userId);
                var winnerName = game.BlueUserId == userId ? game.BlueUser.Email : game.RedUser.Email;
                var loserName = game.BlueUserId == userId ? game.RedUser.Email : game.BlueUser.Email;

                var winnerId = game.BlueUserId == userId ? game.BlueUserId : game.RedUserId;
                var loserId = game.BlueUserId == userId ? game.RedUserId : game.BlueUserId;

                var winNote = new Notification
                {
                    Message = string.Format("You beat {0} in game\\{1}", loserName, game.Name),
                    DateCreated = DateTime.UtcNow,
                    Type = NotificationType.GameWon,
                    State = State.Unread,
                    GameId = id,
                    UserId = winnerId
                };

                var loseNote = new Notification
                {
                    Message = string.Format("{0} beat you in game\\{1}", winnerName, game.Name),
                    DateCreated = DateTime.UtcNow,
                    Type = NotificationType.GameLost,
                    State = State.Unread,
                    GameId = id,
                    UserId = loserId
                };

                this.notifications.Add(winNote);
                this.notifications.Add(loseNote);
            }
            else
            {
                var turnNote = new Notification
                {
                    Message = string.Format("It is your turn in game\\{0}", game.Name),
                    DateCreated = DateTime.UtcNow,
                    Type = NotificationType.YourTurn,
                    State = State.Unread,
                    GameId = id,
                    UserId = userId
                };

                this.notifications.Add(turnNote);
            }
            
            game.Guesses.Add(newGuess);
            this.games.SaveChanges();

            return newGuess.Id;
        }

        private void UpdateRanks(string blueId, string redId, string userId)
        {
            var blue = this.users.GetById(blueId);
            var red = this.users.GetById(redId);

            if (blueId == userId)
            {
                blue.Rank += 100;
                blue.Wins++;
                red.Rank += 15;
                red.Losses++;
            }
            else
            {
                red.Rank += 100;
                red.Wins++;
                blue.Rank += 15;
                blue.Losses++;
            }
        }

        private string GetPlayerNumber(Game game, string userId)
        {
            if (game.BlueUserId == userId)
            {
                return game.RedNumber;
            }

            return game.BlueNumber;
        }

        private void CalculateResult(Guess newGuess, Game gamePlayed, string number, string userId)
        {
            string playerNumber = this.GetPlayerNumber(gamePlayed, userId);
            int cows = 0;
            int bulls = 0;

            for (int i = 0; i < playerNumber.Length; i++)
            {
                if (playerNumber[i] == number[i])
                {
                    bulls++;
                }
            }

            for (int j = 0; j < playerNumber.Length; j++)
            {
                for (int i = 0; i < playerNumber.Length; i++)
                {
                    if ((playerNumber[i] == number[j]) && (i != j))
                    {
                        cows++;
                    }
                }
            }

            newGuess.BullsCount = bulls;
            newGuess.CowsCount = cows;
        }

        private void ChangeGameState(Game game, string userId, int bulls)
        {
            if (bulls == 4)
            {
                game.GameState = GameState.Finished;
            }
            else if (game.BlueUserId == userId)
            {
                game.GameState = GameState.RedInTurn;
            }
            else 
            {
                game.GameState = GameState.BlueInTurn;
            }
        }
    }
}
