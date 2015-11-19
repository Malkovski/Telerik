namespace BullsAndCows.Services.Data.Contracts
{
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public interface IGuessService
    {
        IQueryable<Guess> GetById(int id);
    }
}
