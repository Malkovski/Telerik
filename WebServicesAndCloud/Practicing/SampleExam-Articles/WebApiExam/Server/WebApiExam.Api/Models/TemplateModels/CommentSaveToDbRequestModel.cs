namespace WebApiExam.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class CommentSaveToDbRequestModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            
        }
    }
}