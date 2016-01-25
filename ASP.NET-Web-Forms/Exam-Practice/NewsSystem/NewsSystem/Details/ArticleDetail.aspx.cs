using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Details
{
    public partial class ArticleDetail : Page
    {
        private NewsDbContext content;

        public ArticleDetail()
        {
            this.content = new NewsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article FormViewArticleDetail_GetItem([QueryString("id")]int? id)
        {
            return this.content.Articles.FirstOrDefault(x => x.Id == id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewArticleDetail_UpdateItem(int id)
        {
            NewsSystem.Models.Article item = null;
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
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        protected void ButtonUpVote_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Request.QueryString["id"]);
            var currentArticle = this.content.Articles.FirstOrDefault(x => x.Id == id);
            currentArticle.Likes += 1;

            this.content.SaveChanges();
        }

        protected void ButtonDownVote_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Request.QueryString["id"]);
            var currentArticle = this.content.Articles.FirstOrDefault(x => x.Id == id);
            currentArticle.Likes -= 1;

            this.content.SaveChanges();
        }
    }
}