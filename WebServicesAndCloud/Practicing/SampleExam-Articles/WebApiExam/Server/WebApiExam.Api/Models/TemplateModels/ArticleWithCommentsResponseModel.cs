namespace WebApiExam.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class ArticleWithCommentsResponseModel
    {
        public static Expression<Func<Article, ArticleWithCommentsResponseModel>> FromGameWithDetails
        {
            get
            {
                return a => new ArticleWithCommentsResponseModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    DateCreated = a.CreatedOn,
                    Category = a.Category,
                    Tags = a.Tags,
                    Comments = a.Comments.Select(g => new CommentResponseModel
                    {
                        Id = g.Id,
                        Content = g.Content,
                        DateCreated = g.DateCreated,
                        AuthorName = g.AuthorName
                    }),
           
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; }        
    }
}