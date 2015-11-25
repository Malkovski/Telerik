namespace TeleimotBg.Api.Models.TemplateModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class RateSaveModel
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}