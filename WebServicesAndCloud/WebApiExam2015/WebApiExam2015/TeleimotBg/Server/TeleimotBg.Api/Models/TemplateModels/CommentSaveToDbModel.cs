﻿namespace TeleimotBg.Api.Models.TemplateModels
{
    using System.ComponentModel.DataAnnotations;

    using TeleimotBg.GlobalConstants;

    public class CommentSaveToDbModel
    {
        [Required]
        public int RealEstateId { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCommentLen)]
        [MaxLength(ValidationConstants.MaxCommentLen)]
        public string Content { get; set; }
    }
}