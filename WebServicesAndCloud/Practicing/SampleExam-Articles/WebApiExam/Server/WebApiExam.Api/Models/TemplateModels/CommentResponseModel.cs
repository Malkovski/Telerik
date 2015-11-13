namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Linq;

    public class CommentResponseModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}