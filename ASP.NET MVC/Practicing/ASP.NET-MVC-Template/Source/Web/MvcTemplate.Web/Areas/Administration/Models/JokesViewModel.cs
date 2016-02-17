namespace MvcTemplate.Web.Areas.Administration.Models
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class JokesViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokesViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}