namespace YouTubePlaylist.Web.Authorized
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YouTubePlaylist.Web.Models;

    public partial class FilteredPlaylists : Page
    {
        private YoutubeDbContext content;

        public FilteredPlaylists()
        {
            this.content = new YoutubeDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<Playlist> FilteredForm_GetItem([QueryString("filterBy")]string text)
        {

            var a = this.content.Playlists.Where(x => x.Title.Contains(text));
            return a;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Playlist> ListViewPlaylists_GetData([QueryString("filterBy")]string text)
        {
            var a = this.content.Playlists.Where(x => x.Title.Contains(text)).OrderBy(x => x.Id);
            return a;
        }
    }
}