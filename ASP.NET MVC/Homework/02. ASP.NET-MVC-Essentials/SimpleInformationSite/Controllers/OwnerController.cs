namespace SimpleInformationSite.Controllers
{
    using Models;
    using System.Web.Mvc;

    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            var owner = new Owner() { Name = "Pesho Konq", Age = 44, ShopsOwnded = 11 };
            return View(owner);
        }

        public ActionResult Collect()
        {
            return View();
        }

        public ActionResult Asistents(string name, int age)
        {
            var person = new Owner() { Name = name, Age = age, ShopsOwnded = 0 };
            return View(person);
        }
    }
}