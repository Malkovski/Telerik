﻿namespace SimpleForum.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using SimpleForum.Services.Data.Contracts;
    using SimpleForum.Api.Models.TemplateModels;
    using SimpleForum.GlobalConstants;
    using Microsoft.AspNet.Identity;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/threads")]
    public class ThreadsController : ApiController
    {
        private readonly IThreadService threads;

        public ThreadsController(IThreadService threadService)
        {
            this.threads = threadService;
        }

        public IHttpActionResult Get()
        {
            //Getting instance if needed!!!!!!!!!!!
            //ObjectFactory.Get<ITemplateService>();

            var result = this.threads
                .All(page: 1)
                .ProjectTo<ThreadResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetByCategory(string category)
        {
            var result = this.threads
                .All(page: 1, pageSize: int.MaxValue)
                .Where(x => x.Categories.Any(z => z.Name == category))
                .OrderByDescending(x => x.DateCreated)
                .ProjectTo<ThreadResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult GetByPages(string page, string count)
        {
            var p = int.Parse(page);
            var c = int.Parse(count);

            var result = this.threads
                .All(p, c)
                .OrderByDescending(x => x.DateCreated)
                .ProjectTo<ThreadResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Project id cannot be null or empty!");
            }

            var result = this.threads.All()
                                .Where(a => a.Id == 0)
                                .ProjectTo<ThreadResponseModel>()
                                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(int page, int pageSize = UtilityConstants.DefaultPageSize)
        {
            var result = this.threads
                .All(page, pageSize)
                .ProjectTo<ThreadResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        [Route("create")]
        public IHttpActionResult Post(ThreadSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var createdThreadId = this.threads.Add(model.Title, model.Content, model.Category, userId);

            return this.Ok(string.Format("Created thread with id {0}", createdThreadId));
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/AddTo")]
        public IHttpActionResult AddCategory(int id, string category)
        {
            //VALIDATE!!!!
            var exists = this.threads.All(1, int.MaxValue).Where(x => x.Id == id).FirstOrDefault();

            if (exists == null)
            {
                return this.NotFound();
            }

            var current = this.threads.AddCategory(id, category);

            return this.Ok(string.Format("Added new category for thread {0}", current));
        }
    }
}