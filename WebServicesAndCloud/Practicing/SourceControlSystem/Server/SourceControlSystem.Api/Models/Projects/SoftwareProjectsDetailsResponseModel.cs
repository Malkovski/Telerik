namespace SourceControlSystem.Api.Models.Projects
{
    using AutoMapper;
    using SourceControlSystem.Api.Infrastucture.Mappings;
    using SourceControlSystem.Models;
    using System;
    using System.Linq;

    public class SoftwareProjectsDetailsResponseModel : IMapFrom<SoftwareProject>, IHaveCustomMappings  
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<SoftwareProject, SoftwareProjectsDetailsResponseModel>()
                .ForMember(s => s.TotalUsers, opt => opt.MapFrom(s => s.Users.Count()));
        }
    }
}