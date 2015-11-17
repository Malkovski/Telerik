﻿namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class CommentSaveToDbRequestModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

    }
}