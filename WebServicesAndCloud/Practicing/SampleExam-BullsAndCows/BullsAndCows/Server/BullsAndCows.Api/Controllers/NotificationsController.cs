namespace BullsAndCows.Api.Controllers
{
    using BullsAndCows.Services.Data.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using BullsAndCows.Api.Models.TemplateModels;
    using System.Net;

    [RoutePrefix("api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly INotificationService notes;

        public NotificationsController(INotificationService notes)
        {
            this.notes = notes;
        }

        public IHttpActionResult Get()
        {
            var result = this.notes.All(this.User.Identity.GetUserId())
                .ProjectTo<NotificationResponseModel>()
                .ToList();
               
            return this.Ok(result);
        }

        public IHttpActionResult Get(string page)
        {
            var p = int.Parse(page);

            var result = this.notes.All(this.User.Identity.GetUserId(), p)
                .ProjectTo<NotificationResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Route("next")]
        [HttpGet]
        public IHttpActionResult Next()
        {
            var result = this.notes
                .Next(this.User.Identity.GetUserId());

            if (result.Count() != 0)
            {
                result
                    .ProjectTo<NotificationResponseModel>()
                        .FirstOrDefault();
            }
            else
            {
                return this.StatusCode(HttpStatusCode.NotModified);
            }
                
            return this.Ok(result);
        }
    }
}