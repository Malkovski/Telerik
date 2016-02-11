namespace Working_with_Data.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}