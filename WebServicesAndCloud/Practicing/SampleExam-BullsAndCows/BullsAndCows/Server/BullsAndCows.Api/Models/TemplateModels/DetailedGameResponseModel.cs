namespace BullsAndCows.Api.Models.TemplateModels
{
    using AutoMapper;
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DetailedGameResponseModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public IEnumerable<GuessResponseModel> YourGuesses { get; set; }

        public IEnumerable<GuessResponseModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            string userId = null;
            config.CreateMap<Game, DetailedGameResponseModel>()
                .ForMember(x => x.Blue, opt => opt.MapFrom(x => x.BlueUser == null ? "No blue player yet" : x.BlueUser.UserName))
                    .ForMember(x => x.Red, opt => opt.MapFrom(x => x.RedUser.UserName))
                    .ForMember(x => x.GameState, opt => opt.MapFrom(x => x.GameState.ToString()))
                    .ForMember(x => x.YourNumber, opt => opt.MapFrom(x => x.BlueUserId == userId ? x.BlueNumber : x.RedNumber))
                    .ForMember(x => x.YourColor, opt => opt.MapFrom(x => x.BlueUserId == userId ? "Blue" : "Red"))
                    .ForMember(x => x.YourGuesses, opt => opt.MapFrom(x => x.Guesses.Where(z => z.UserId == userId)))
                    .ForMember(x => x.OpponentGuesses, opt => opt.MapFrom(x => x.Guesses.Where(z => z.UserId != userId)));
        }
    }
}