namespace Working_with_Data.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Working_with_Data.Data.UnitOfWork;

    public class UsersController : Controller
    {
        private UowData Data = new UowData();

        public ActionResult Info(string id)
        {
            var user = Data.Users.All().FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        public ActionResult Info7()
        {
            var query = Request.QueryString["name"];
            return RedirectToAction("Taged", "Tweets", new { name = query });
        }
    }
}