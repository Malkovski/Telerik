namespace YouTubePlaylist.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
using YouTubePlaylist.Web.Models;

    public partial class _Default : Page
    {
        private YoutubeDbContext content;

        public _Default()
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
        public IQueryable<Playlist> lvPlaylistsHome_GetData()
        {
            return this.content.Playlists.OrderByDescending(x => x.Ratings.Count).Take(10);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var text = this.PlaylistSearch.Text;
            this.Response.Redirect(string.Format("~/Authorized/FilteredPlaylists.aspx?filterBy={0}", text));
        }
    }
}