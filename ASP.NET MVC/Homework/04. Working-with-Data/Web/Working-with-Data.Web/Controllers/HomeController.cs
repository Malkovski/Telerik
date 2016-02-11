namespace Working_with_Data.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class HomeController : Controller
    {
        private UowData Data = new UowData();

        public ActionResult Index()
        {
            var users = Data.Users.All().ToList();
            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}