namespace BullsAndCows.Services.Data
{
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Data.Contracts;
    using System;
    using System.Linq;

    public class GuessService : IGuessService
    {
        private readonly IRepository<Guess> guesses;

        public GuessService(IRepository<Guess> guessRepo)
        {
            this.guesses = guessRepo;
        }

        public IQueryable<Guess> GetById(int id)
        {
            return this.guesses.All().Where(x => x.Id == id);
        }
    }
}
