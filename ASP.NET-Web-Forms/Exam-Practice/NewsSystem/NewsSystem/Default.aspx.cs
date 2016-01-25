namespace NewsSystem
{
    using NewsSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Default : Page
    {
        private NewsDbContext content;

        public _Default()
        {
            this.content = new NewsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Article> LictViewMostPopularArticles_GetData()
        {
            return this.content.Articles.OrderByDescending(x => x.Likes).Take(3);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewAllCategoriesHomePage_GetData()
        {
            return this.content.Categories.OrderBy(x => x.Name);
        }
    }
}