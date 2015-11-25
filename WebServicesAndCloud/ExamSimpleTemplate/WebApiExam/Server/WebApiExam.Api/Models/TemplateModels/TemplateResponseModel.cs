namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using WebApiExam.GlobalConstants;

    public class TemplateResponseModel
    {
        [Required]
        [MaxLength(ValidationConstants.MaxModelName)]
        public string Name { get; set; }
    }
}