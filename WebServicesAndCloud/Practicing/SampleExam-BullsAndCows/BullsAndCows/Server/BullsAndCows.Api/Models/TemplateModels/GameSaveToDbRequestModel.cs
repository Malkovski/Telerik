namespace BullsAndCows.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;

    public class GameSaveToDbRequestModel : IMapFrom<Game>
    {
        public string Name { get; set; }

        public string Number { get; set; }
    }
}