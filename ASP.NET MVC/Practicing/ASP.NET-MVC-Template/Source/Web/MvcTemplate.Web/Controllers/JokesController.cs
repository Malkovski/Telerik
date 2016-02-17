namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;

        public JokesController(IJokesService jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult ById(int id)
        {
            // var intId = int.Parse(id);
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {

            var page = id;
            var jokesCount = this.jokes.GetCount();

            var result = this.Cache.Get(
                "Jokes_page_" + id,
                () => this.jokes.All(page).To<JokeViewModel>().ToList(),
                30);
            //var result = this.jokes.All(page).To<JokeViewModel>().ToList();

            var totalpages = (int)Math.Ceiling(jokesCount / (decimal)GlobalConstants.ItemsPerPage);

            var viewModel = new CustomGridViewModel
            {
                Jokes = result,
                CurrentPage = id,
                TotalPages = totalpages
            };

            return this.View(viewModel);
        }
    }
}
