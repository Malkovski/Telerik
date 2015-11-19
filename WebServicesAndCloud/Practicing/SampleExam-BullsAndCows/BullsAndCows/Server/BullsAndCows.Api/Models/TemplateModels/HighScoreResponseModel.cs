namespace BullsAndCows.Api.Models.TemplateModels
{
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public class HighScoreResponseModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public int Rank { get; set; }
    }
}