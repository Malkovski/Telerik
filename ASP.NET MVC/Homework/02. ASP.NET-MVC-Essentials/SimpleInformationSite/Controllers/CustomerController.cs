namespace SimpleInformationSite.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Greeting = "Hello customer!";
            return View();
        }

        public ActionResult Goods()
        {
            var goods = new List<string>() { "Bread", "Milk", "Rakia", "Soap", "Toilet paper"};
            return View(goods);
        }
    }
}