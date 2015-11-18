namespace SimpleForum.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;

    public class PostSaveDbRequestModel : IMapFrom<Post>
    {
        public string Content { get; set; }
    }
}