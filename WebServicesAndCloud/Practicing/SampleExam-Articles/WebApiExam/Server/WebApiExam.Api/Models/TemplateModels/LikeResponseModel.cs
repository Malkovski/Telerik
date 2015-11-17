namespace WebApiExam.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class LikeResponseModel : IMapFrom<Like>, IHaveCustomMappings
    {
        public string Like { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Like, LikeResponseModel>()
                .ForMember("Like", x => x.MapFrom(z => z.Id));
        }
    }
}