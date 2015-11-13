namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class ArticleWithCommentsResponseModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
            config.CreateMap<Article, ArticleWithCommentsResponseModel>()
                .ForMember(s => s.Category, opt => opt.MapFrom(s => s.Category.Name));
        }
    }
}