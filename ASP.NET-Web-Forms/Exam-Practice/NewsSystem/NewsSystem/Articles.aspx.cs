namespace NewsSystem
{
    using NewsSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;

    public partial class Articles : System.Web.UI.Page
    {
        private NewsDbContext content;

        public Articles()
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
        public IQueryable<NewsSystem.Models.Article> ListViewArticles_GetData()
        {
            return this.content.Articles;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_UpdateItem(int id)
        {
            Article item = this.content.Articles.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.SaveChanges();
            }
        }

        public void ListViewArticles_InsertItem()
        {
            var item = new Article();
            item.UserId = this.User.Identity.GetUserId();
            item.DateCreated = DateTime.Now;

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.Articles.Add(item);
                this.content.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_DeleteItem(int id)
        {
            Article item = this.content.Articles.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.content.Articles.Remove(item);
            this.content.SaveChanges();
        }

        public void FormViewInsertArticle_InsertItem()
        {
            var item = new Article();
            item.UserId = this.User.Identity.GetUserId();
            item.DateCreated = DateTime.Now;

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.Articles.Add(item);
                this.content.SaveChanges();
            }
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.content.Categories.OrderBy(x => x.Id);
        }

        protected void LinkToCreateArticle_Click(object sender, EventArgs e)
        {
            var currentClass = this.CreateArticle.CssClass;
            if (currentClass == "hidden")
            {
                this.CreateArticle.CssClass = "";
                this.LinkToCreateArticle.Text = "Close";
            }
            else
            {
                this.CreateArticle.CssClass = "hidden";
                this.LinkToCreateArticle.Text = "Insert new Article";
            }
        }
    }
}