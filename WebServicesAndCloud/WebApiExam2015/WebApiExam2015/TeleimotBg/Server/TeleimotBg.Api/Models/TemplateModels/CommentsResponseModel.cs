namespace TeleimotBg.Api.Models.TemplateModels
{
    using System;

    using AutoMapper;

    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.Models;

    public class CommentsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommentsResponseModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}