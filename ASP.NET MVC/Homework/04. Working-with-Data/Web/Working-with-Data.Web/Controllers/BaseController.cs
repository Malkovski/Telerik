namespace Working_with_Data.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;


    public class BaseController : Controller
    {

        public BaseController(IUowData data)
        {
            Data = data;
        }

        protected IUowData Data { get; set; }
    }
}