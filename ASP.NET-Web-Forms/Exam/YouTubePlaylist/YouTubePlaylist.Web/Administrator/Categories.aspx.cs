namespace YouTubePlaylist.Web.Administrator
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YouTubePlaylist.Web.Models;

    public partial class Categories : Page
    {
        private YoutubeDbContext content;

        public Categories()
        {
            this.content = new YoutubeDbContext();
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
        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.content.Categories.OrderBy(x => x.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int id)
        {
            Category item = this.content.Categories.Find(id);
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

        public void ListViewCategories_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.Categories.Add(item);
                this.content.SaveChanges();
            }
        }

        protected void CategoryNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
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

    }
}