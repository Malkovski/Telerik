namespace MoviesSystem.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Mvc;


    public class MoviesController : Controller
    {
        private MoviesDbContext content;

        public MoviesController()
        {
            this.content = new MoviesDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var movies = this.content.Movies.AsQueryable().ToList();
            return View(movies);
        }

        public ActionResult GetTitleById(int id)
        {
            var res = this.Request.IsAjaxRequest();
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var movie = this.content.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Book not found");
            }

            return Content(movie.Title);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Year, Director, Studio, StudioAddress")] Movie movie)
        {
            var res = this.Request.IsAjaxRequest();
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (movie.Id == 0)
                    {
                        content.Movies.Add(movie);
                    }
                    else
                    {
                        content.Entry(movie).State = EntityState.Modified;
                    }

                    content.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }

            return Redirect("Create");
        }

        public JsonResult All()
        {
            var movies = this.content.Movies.AsQueryable().Select(x => new
            {
                Title = x.Title,
                Year = x.Year,
                Director = x.Director,
                LeadingMaleRole = x.LeadingMaleRole.Name,
                LeadindFemaleRole = x.LeadingFemaleRole.Name
            });

            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}