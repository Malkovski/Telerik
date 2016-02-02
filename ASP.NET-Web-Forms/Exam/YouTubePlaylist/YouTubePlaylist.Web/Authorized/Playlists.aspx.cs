namespace YouTubePlaylist.Web.Authorized
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YouTubePlaylist.Web.Models;
    using Microsoft.AspNet.Identity;

    public partial class Playlists : Page
    {
        private YoutubeDbContext content;

        public Playlists()
        {
            this.content = new YoutubeDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Playlist> ListViewPlaylists_GetData()
        {
            return this.content.Playlists.OrderBy(x => x.Id);
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.content.Categories.OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewPlaylists_UpdateItem(int id)
        {
            Playlist item = null;
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

        public void ListViewPlaylists_InsertItem()
        {
            var item = new YouTubePlaylist.Web.Models.Playlist();
            TryUpdateModel(item);

            item.CreatorId = this.User.Identity.GetUserId();
            item.CreationDate = DateTime.UtcNow;

            if (ModelState.IsValid)
            {
                this.content.Playlists.Add(item);
                this.content.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewPlaylists_DeleteItem(int id)
        {

        }

        protected void btnInsertNewPlaylist_Click(object sender, EventArgs e)
        {
            this.ListViewPlaylists.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void LinkButtonArticlesInsertCancel_Click(object sender, EventArgs e)
        {
            this.ListViewPlaylists.InsertItemPosition = InsertItemPosition.None;
        }
    }
}