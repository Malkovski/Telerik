namespace WebtoollikeCalculator.Controllers
{
    using Models;
    using System.Web.Mvc;

    public class CalcController : Controller
    {
        // GET: Calc
        [HttpGet]
        public ActionResult Index()
        {
            var c = new Calculator() { Quantity = 1, Type = Type.Bit, Kilo = Kilo.a };
            return View(c);
        }

        [HttpPost]
        public ActionResult Index(Calculator calc)
        {
            
            return View(calc);
        }
    }
}