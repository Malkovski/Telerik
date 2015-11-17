namespace SimpleForum.Api.Models.TemplateModels
{
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;
    using System;
    using System.Linq;

    public class CommentSaveModel : IMapFrom<Comment>
    {
        public string Text { get; set; }
    }
}