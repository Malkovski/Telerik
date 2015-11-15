namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class AlertResponseModel : IMapFrom<Alert>
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpireOn { get; set; }
    }
}