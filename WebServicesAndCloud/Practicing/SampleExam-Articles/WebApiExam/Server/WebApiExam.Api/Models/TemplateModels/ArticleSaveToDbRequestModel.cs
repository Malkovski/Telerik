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
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Tag> Tags { get; set; }
        

        // logic for multi mapping
        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Tag, string>()
                .ProjectUsing(x => x.Name);

            config.CreateMap<Article, ArticleResponseModel>()
                .ForMember(s => s.Tags, opt => opt.MapFrom(s => s.Tags.ToList()));

            config.CreateMap<Article, ArticleResponseModel>()
               .ForMember(s => s.DateCreated, opt => opt.MapFrom(s => s.CreatedOn));

            config.CreateMap<Article, ArticleWithCommentsResponseModel>()
               .ForMember(s => s.Comments,  opt => opt.MapFrom(s => s.Comments));

           
        }
    }
}