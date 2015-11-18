namespace BullsAndCows.Api.Models.TemplateModels
{
    using AutoMapper;
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public class GuessResponseModel : IMapFrom<Guess>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Guess, GuessResponseModel>()
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}