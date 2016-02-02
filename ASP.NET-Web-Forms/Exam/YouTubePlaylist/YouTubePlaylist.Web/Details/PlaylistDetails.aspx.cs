namespace YouTubePlaylist.Web.Details
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YouTubePlaylist.Web.Models;
    using Microsoft.AspNet.Identity;

    public partial class PlaylistDetails : Page
    {
        private YoutubeDbContext content;

        public PlaylistDetails()
        {
            this.content = new YoutubeDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Playlist FormViewPlaylistDetail_GetItem([QueryString("id")]int? id)
        {
            return this.content.Playlists.FirstOrDefault(x => x.Id == id);
        }


        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Video> RepeaterVideosHomePage_GetData()
        {
            return this.content.Videos.OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void RepeaterVideosHomePage_DeleteItem(int id)
        {
            var videoToDel = this.content.Videos.Find(id);
            this.content.Videos.Remove(videoToDel);
            this.content.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewPlaylistDetail_DeleteItem(int id)
        {
            Playlist item = this.content.Playlists.Find(id);

            if (item.CreatorId != this.User.Identity.GetUserId())
            {
                return;
            }

            var videos = this.content.Videos.Where(x => x.PlaylistId == item.Id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            this.content.Videos.RemoveRange(videos);
            this.content.Playlists.Remove(item);
            this.content.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public Playlist FormViewPlaylistDetail_UpdateItem(int id)
        {
            Playlist item = this.content.Playlists.Find(id);

            return item;
        }
        
    }
}