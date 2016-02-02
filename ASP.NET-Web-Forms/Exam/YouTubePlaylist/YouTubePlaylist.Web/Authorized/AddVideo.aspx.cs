namespace YouTubePlaylist.Web.Authorized
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YouTubePlaylist.Web.Models;

    public partial class AddVideo : Page
    {
        private YoutubeDbContext content;

        public AddVideo()
        {
            this.content = new YoutubeDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Playlist FormViewAddVideo_GetItem(int id)
        {
            return this.content.Playlists.FirstOrDefault(x => x.Id == id);
        }

        public void FormViewAddVideo_InsertItem()
        {
            var item = new YouTubePlaylist.Web.Models.Playlist();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewAddVideo_UpdateItem(int id)
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


        protected void LinkButtonPlaylistInsert_Click(object sender, EventArgs e)
        {
            var newVideoUrl = this.TextBoxNewVideo.Text;
            var id = int.Parse(this.Request.QueryString["id"]);

            var newVideo = new Video()
            {
                Url = newVideoUrl,
                PlaylistId = id
            };

            Playlist current = this.FormViewAddVideo_GetItem(id);
            current.Videos.Add(newVideo);
            this.content.SaveChanges();
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBoxNewVideo.Text = "";
            this.Response.Redirect(this.Request.RawUrl);
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