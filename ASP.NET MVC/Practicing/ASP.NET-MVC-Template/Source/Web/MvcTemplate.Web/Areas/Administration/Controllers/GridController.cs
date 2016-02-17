namespace MvcTemplate.Web.Areas.Administration.Views.Administation
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data;
    using Web.Controllers;

    public class GridController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService categories;

        public GridController(IJokesService jokes, ICategoriesService categories)
        {
            this.jokes = jokes;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            this.ViewBag.CategoryNames = this.categories.GetAll().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

            return this.View();
        }

        public ActionResult JokesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var jokesViewModels = this.jokes.All().To<JokesViewModel>();
            DataSourceResult result = jokesViewModels.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JokesViewModels_Create([DataSourceRequest]DataSourceRequest request, JokesViewModel jokesViewModel)
        {
            int createdId = 0;
            if (this.ModelState.IsValid)
            {
                // for working with autocomplete
                var category = this.categories.GetAll().FirstOrDefault(x => x.Name == jokesViewModel.Category);

                // for working with dropdown
                // var category = this.categories.GetAll().FirstOrDefault(x => x.Id == jokesViewModel.CategoryId);
               createdId = this.jokes.Create(jokesViewModel.Content, category.Id);
            }

            var result = this.jokes.All().To<JokesViewModel>().FirstOrDefault(x => x.Id == createdId);
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JokesViewModels_Update([DataSourceRequest]DataSourceRequest request, JokesViewModel jokesViewModel)
        {
            var category = this.categories.GetAll().FirstOrDefault(x => x.Name == jokesViewModel.Category);

            if (this.ModelState.IsValid)
            {
                var updatedId = this.jokes.Update(jokesViewModel.Id, category.Id, jokesViewModel.Content);
            }

            var result = this.jokes.All().To<JokesViewModel>().FirstOrDefault(x => x.Id == jokesViewModel.Id);
            return this.Json(new[] { jokesViewModel }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JokesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, JokesViewModel jokesViewModel)
        {
            this.jokes.Delete(jokesViewModel.Id);
            return this.Json(new[] { jokesViewModel }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoryNames()
        {
            var result = this.categories.GetNames();
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
