namespace MvcTemplate.Web.ViewModels.Home
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Sanitizer;
    using Services.Web;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        // wrong i guess!!
        private ISanitizer sanitizer = new HtmlSanitizerAdapter();

        public int Id { get; set; }

        public string SanitizedContent
        {
            get { return this.sanitizer.Sanitize(this.Content); }
        }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LikesCount { get; set; }

        public string Category { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Joke/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));

            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Sum(l => (int)l.Type) : 0));
        }
    }
}
