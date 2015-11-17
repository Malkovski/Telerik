namespace SimpleForum.Api.Models.TemplateModels
{
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;
    using System;
    using System.Linq;

    public class CategoryResponseModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}