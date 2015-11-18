namespace SimpleForum.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using SimpleForum.Api.Infrastructure.Mappings;
    using SimpleForum.Models;

    public class ThreadSaveToDbRequestModel : IMapFrom<Thread>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }
    }
}