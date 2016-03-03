namespace TeleimotBg.Api.Models.TemplateModels
{
    using System.ComponentModel.DataAnnotations;

    public class RateSaveModel
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}