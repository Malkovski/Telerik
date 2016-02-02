using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylist.Web.Models;
using Microsoft.AspNet.Identity;

namespace YouTubePlaylist.Web.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private YoutubeDbContext content;

        public Manage()
        {
            this.content = new YoutubeDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public User USerInfo_GetItem(string id)
        {
            var currentId = this.User.Identity.GetUserId();
            var a = this.content.Users.Find(currentId);

            return a;
        }

    }
}