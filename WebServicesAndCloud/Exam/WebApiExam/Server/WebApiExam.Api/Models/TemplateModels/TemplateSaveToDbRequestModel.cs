namespace WebApiExam.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class TemplateSaveToDbRequestModel : IMapFrom<Model1>, IHaveCustomMappings
    {
        public int Id { get; set; }

        // logic for multi mapping
        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Model1, TemplateResponseModel>();
                //.ForMember(s => s.TotalUsers, opt => opt.MapFrom(s => s.Users.Count()));
        }
    }
}