namespace WebApiExam.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using WebApiExam.Api.Models.TemplateModels;
    using WebApiExam.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;

    public class AlertsController : ApiController
    {
        private readonly IAlertService alert;

        public AlertsController(IAlertService alertService)
        {
            this.alert = alertService;
        }

        public IHttpActionResult Get()
        {
            var result = this.alert.All()
                .Where(x => x.ExpireOn > DateTime.Now)
                .ProjectTo<AlertResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(AlertSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAlertId = this.alert.Add(model.Message, model.DaysOfValidity);

            var result = this.alert
                .GetById(newAlertId)
                .ProjectTo<AlertResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}
