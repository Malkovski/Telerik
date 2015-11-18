namespace BullsAndCows.Api.Models.TemplateModels
{
    using AutoMapper;
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public class CreatedGameResponseModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Game, CreatedGameResponseModel>()
                .ForMember(x => x.Blue, opt => opt.MapFrom(x => x.BlueUser == null ? "No blue player yet" : x.BlueUser.UserName))
                    .ForMember(x => x.Red, opt => opt.MapFrom(x => x.RedUser.UserName))
                    .ForMember(x => x.GameState, opt => opt.MapFrom(x => x.GameState.ToString()));
        }
    }
}