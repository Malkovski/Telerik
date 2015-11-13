namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleResponseModel 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public List<string> Tags { get; set; }
    }
}