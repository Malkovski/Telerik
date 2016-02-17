namespace MvcTemplate.Web.Areas.Administration.Models
{
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class CategoriesViewModel : IMapFrom<JokeCategory>
    {
        public string Name { get; set; }
    }
}