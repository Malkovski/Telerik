namespace MvcTemplate.Web.ViewModels.Home
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LikesViewModel : IMapFrom<Like>, IHaveCustomMappings
    {
        public LikeType Type { get; set; }

        public string Author { get; set; }

        public string Joke { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Like, LikesViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(z => z.User.UserName));

            configuration.CreateMap<Like, LikesViewModel>()
                .ForMember(x => x.Joke, opt => opt.MapFrom(z => z.Joke.Id));
        }
    }
}