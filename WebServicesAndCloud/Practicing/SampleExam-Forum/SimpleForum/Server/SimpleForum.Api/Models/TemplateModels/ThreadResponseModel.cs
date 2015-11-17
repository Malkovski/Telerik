namespace SimpleForum.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;
    using AutoMapper;

    public class ThreadResponseModel : IHaveCustomMappings
    {
        public int id { get; set; }

        public string title { get; set; }

        public DateTime dateCreated { get; set; }

        public string content { get; set; }

        public string createdBy { get; set; }

        public IEnumerable<CategoryResponseModel> categories { get; set; }

        public IEnumerable<PostResponseModel> posts { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Thread, ThreadResponseModel>()
                 .ForMember(x => x.createdBy, opt => opt.MapFrom(x =>
                     x.User.Email));
        }
    }
}