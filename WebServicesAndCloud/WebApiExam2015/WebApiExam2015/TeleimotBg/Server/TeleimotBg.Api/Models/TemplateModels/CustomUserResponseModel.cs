namespace TeleimotBg.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.Models;

    public class CustomUserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public float Rating { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            
        }
    }
}