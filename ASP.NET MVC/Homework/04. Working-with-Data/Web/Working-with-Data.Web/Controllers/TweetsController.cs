namespace Working_with_Data.Web.Controllers
{
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Working_with_Data.Models;

    public class TweetsController : Controller
    {
        private UowData Data = new UowData();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult MyTweets()
        {
            var id = this.User.Identity.GetUserId();
            var tweets = Data.Tweets.All().Where(x => x.UserId == id).ToList();
            return View(tweets);
        }

        public ActionResult Taged(string name)
        {
            var tag = "#" + name;
            var tweets = Data.Tweets.All().Where(x => x.Tags.Any(z => z.Name == tag)).ToList();

            return View(tweets);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
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

                return RedirectToAction("MyTweets");
            }

            return View(viewModel);
        }

        public JsonResult GetTweetsByUser(string id)
        {
            var tweets = Data.Tweets.All().Where(x => x.UserId == id).Select( x => 
                new {

                Content = x.Content,
                User = x.User,
                CreatedOn = x.CreatedOn,


                }).ToList();
            return Json(tweets, JsonRequestBehavior.AllowGet);
        }
    }
}