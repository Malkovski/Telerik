namespace BullsAndCows.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using BullsAndCows.GlobalConstants;
    using BullsAndCows.Models;

    public interface IGameService
    {
        IQueryable<Game> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize, string userId = null);

        IQueryable<Game> GetGameById(int id);

        int Add(string name, string number, string greatorId);

        bool UserIsPartOfGame(int id, string userId);

        bool GameIsAvailable(int id, string userId);

        string JoinGame(int id, string userId, string number);

        int MakeGuess(Game game, int id, string number, string userId);

        bool CanMakeGuess(Game game, string userId);
    }
}