namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class ArticleResponseModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
            config.CreateMap<Article, ArticleResponseModel>()
                .ForMember(s => s.Category, opt => opt.MapFrom(s => s.Category.Name));

            config.CreateMap<Article, ArticleResponseModel>()
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(s => s.CreatedOn));
        }
    }
}