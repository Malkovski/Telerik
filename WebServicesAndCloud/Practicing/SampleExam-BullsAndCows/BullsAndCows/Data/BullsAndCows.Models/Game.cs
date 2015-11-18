namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private ICollection<Guess> guesses;
 

        public Game()
        {
            this.guesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string RedUserId { get; set; }

        public virtual User RedUser { get; set; }

        public string BlueUserId { get; set; }

        public virtual User BlueUser { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public string BlueNumber { get; set; }

        public string RedNumber { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }
    }
}
