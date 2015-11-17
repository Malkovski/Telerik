namespace SimpleForum.Api.Models.TemplateModels
{
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;
    using System;
    using System.Linq;

    public class PostResponseModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string content { get; set; }

        public DateTime postDate { get; set; }

        public string  rating { get; set; }

        public string postedBy { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
            config.CreateMap<Post, PostResponseModel>()
                .ForMember(x => x.postedBy, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.rating, opt => opt.MapFrom(x => x.Rating.ToString() + "/" + x.Rating.ToString()));   
        }
    }
}