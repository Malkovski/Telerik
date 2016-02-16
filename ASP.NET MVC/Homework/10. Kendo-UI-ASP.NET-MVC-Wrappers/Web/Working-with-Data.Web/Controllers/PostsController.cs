using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Working_with_Data.Data.UnitOfWork;
using Working_with_Data.Models;

namespace Working_with_Data.Web.Controllers
{
    public class PostsController : Controller
    {
        private UowData Data = new UowData();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AutocompleteData()
        {
             var result = Data.Tweets.All().Select(x => x.Content).ToArray();
           // var result = new[] { "asfas", "awdasd", "assdasdasd" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var tweets = this.Data.Tweets.All().AsQueryable().ToDataSourceResult(request);

            return Json(tweets);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, Tweet viewModel)
        {
            if(viewModel != null && this.ModelState.IsValid)
            {
                var tweet = new Tweet();

                var content = viewModel.Content.Split(' ');

                for (int i = 0; i < content.Length; i++)
                {
                    var word = content[i];
                    if (content[i].StartsWith("#"))
                    {

                        var exists = Data.Tags.All().Where(x => x.Name == word).FirstOrDefault();
                        if (exists == null)
                        {
                            var newTag = new Tag() { Name = content[i] };
                            Data.Tags.Add(newTag);
                            Data.SaveChanges();
                            tweet.Tags.Add(newTag);
                        }
                        else
                        {
                            tweet.Tags.Add(exists);
                        }
                    }
                }

                tweet.Content = viewModel.Content;
                tweet.UserId = this.User.Identity.GetUserId();
                tweet.CreatedOn = DateTime.Now;

                Data.Tweets.Add(tweet);
                Data.SaveChanges();

                return Json(new[] { tweet }.ToDataSourceResult(request));
            }

            return Json("?");
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, Tweet viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {

                var tweet = this.Data.Tweets.GetById(viewModel.Id);

                var content = viewModel.Content.Split(' ');

                for (int i = 0; i < content.Length; i++)
                {
                    var word = content[i];
                    if (content[i].StartsWith("#"))
                    {

                        var exists = Data.Tags.All().Where(x => x.Name == word).FirstOrDefault();
                        if (exists == null)
                        {
                            var newTag = new Tag() { Name = content[i] };
                            Data.Tags.Add(newTag);
                            Data.SaveChanges();
                            tweet.Tags.Add(newTag);
                        }
                        else
                        {
                            tweet.Tags.Add(exists);
                        }
                    }
                }

                tweet.Content = viewModel.Content;
                tweet.UserId = this.User.Identity.GetUserId();
                tweet.CreatedOn = DateTime.Now;

                Data.Tweets.Add(tweet);
                Data.SaveChanges();

                return Json(new[] { tweet }.ToDataSourceResult(request));
            }

            return Json("?");
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, Tweet viewModel)
        {
            var tweet = this.Data.Tweets.GetById(viewModel.Id);

            Data.Tweets.Delete(tweet);
                Data.SaveChanges();

            return Json(new[] { tweet }.ToDataSourceResult(request));
        }
    }
}