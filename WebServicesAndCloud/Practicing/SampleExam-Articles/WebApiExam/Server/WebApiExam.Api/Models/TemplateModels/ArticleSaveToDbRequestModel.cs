namespace WebApiExam.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class ArticleSaveToDbRequestModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Tag> Tags { get; set; }
        

        // logic for multi mapping
        public void CreateMappings(IConfiguration config)
        {
            

            //config.CreateMap<Article, ArticleSaveToDbRequestModel>()
            //    .ForMember(s => s.Category, opt => opt.MapFrom(s => s.Category.Name));

            

            //config.CreateMap<Article, ArticleResponseModel>()
            //   .ForMember(s => s.DateCreated, opt => opt.MapFrom(s => s.CreatedOn));
        }
    }
}