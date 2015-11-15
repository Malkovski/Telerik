namespace WebApiExam.Api.Models.TemplateModels
{
    using System;
    using System.Linq;
    using WebApiExam.Api.Infrastructure.Mappings;
    using WebApiExam.Models;

    public class AlertSaveToDbRequestModel : IMapFrom<Alert>, IHaveCustomMappings
    {
        public string Message { get; set; }

        public int DaysOfValidity { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
          
        }
    }
}