namespace MoviesSystem.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public class ActorsController : Controller
    {
        private MoviesDbContext content;

        public ActorsController()
        {
            this.content = new MoviesDbContext();
        }

        public ActionResult Index()
        {
            var actors = this.content.Actors.AsQueryable().ToList();
            return View(actors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Actor actor)
        {
            var res = this.Request.IsAjaxRequest();
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Json("This action can be invoke only by AJAX call");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (actor.Id == 0)
                    {
                        content.Actors.Add(actor);
                    }
                    else
                    {
                        content.Entry(actor).State = EntityState.Modified;
                    }

                    content.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Json(Url.Action("Details", "Actors", new { id = actor.Id }));
        }

        public ActionResult Details(int? id)
        {
            var current = this.content.Actors.FirstOrDefault(x => x.Id == id);
            return this.View(current);
        }

        [HttpPost]
        public JsonResult Update(Actor actor)
        {
            var res = this.Request.IsAjaxRequest();
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Json("This action can be invoke only by AJAX call");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (actor.Id == 0)
                    {
                        content.Actors.Add(actor);
                    }
                    else
                    {
                        content.Entry(actor).State = EntityState.Modified;
                    }

                    content.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            var a = Url.Action("Details", "Actors", new { id = actor.Id });
            return Json(a, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Details", "Actors", new { id = actor.Id });
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            var current = this.content.Actors.FirstOrDefault(x => x.Id == id);
            return this.View(current);
        }

        public JsonResult Delete(int? id)
        {
            var useless = this.content.Actors.FirstOrDefault(x => x.Id == id);

            if (useless != null)
            {
                this.content.Actors.Remove(useless);
                this.content.SaveChanges();
            }

            return Json(Url.Action("Index", "Actors"));
        }
    }
}