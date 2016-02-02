using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylist.Web.Models;

namespace YouTubePlaylist.Web
{
    public partial class CategoryMembers : System.Web.UI.Page
    {
        private YoutubeDbContext content;

        public CategoryMembers()
        {
            this.content = new YoutubeDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Category FormViewCategorymenbers_GetItem([QueryString("category")]int? id)
        {
            return this.content.Categories.FirstOrDefault(x => x.Id == id);
        }
    }
}