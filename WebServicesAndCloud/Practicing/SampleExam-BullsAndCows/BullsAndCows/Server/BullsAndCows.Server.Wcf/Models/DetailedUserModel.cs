namespace BullsAndCows.Server.Wcf.Models
{
    using System;
    using System.Linq;

    public class DetailedUserModel
    {
        public string Id { get; set; }

        public int Losses { get; set; }

        public int Rank { get; set; }

        public string Username { get; set; }

        public int Wins { get; set; }
    }
}