namespace NewsSystem
{
    using NewsSystem.Models;
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Web.ModelBinding;

    public partial class Articles : Page
    {
        private NewsDbContext content;
        private int? flag;

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
        public IQueryable<Article> ListViewArticles_GetData([QueryString]string orderBy)
        {
            var result = this.content.Articles.AsQueryable();

            result = string.IsNullOrEmpty(orderBy) ? result.OrderBy(x => x.Id) : result.OrderBy(orderBy + " Ascending");

            return result; 
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
            if (item.Title == null || item.Content == null)
            {
               //TODO .................
                return;
            }
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

        protected void TextBoxInsertArticleTitleValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void TextBoxNewArticleBodyValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnInsertNewArticle_Click(object sender, EventArgs e)
        {
            this.ListViewArticles.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void LinkButtonArticlesInsertCancel_Click(object sender, EventArgs e)
        {
            this.ListViewArticles.InsertItemPosition = InsertItemPosition.None;
        }

        protected void LinkButtonArticlesInsertCancel_Click1(object sender, EventArgs e)
        {
            this.ListViewArticles.InsertItemPosition = InsertItemPosition.None;
        }
    }
}