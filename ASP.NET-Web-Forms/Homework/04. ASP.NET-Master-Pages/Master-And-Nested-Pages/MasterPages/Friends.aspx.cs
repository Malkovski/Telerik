using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPages
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var friends = new[] 
            {
                new { Name = "Ivan", From = "Work" },
                new { Name = "Petkan", From = "Work" },
                new { Name = "Stoyan", From = "Party" },
                new { Name = "Stefan", From = "School" },
                new { Name = "Dragan", From = "Kindergarden" },
                new { Name = "Koki", From = "AA" }
            };

            this.ListViewFriends.DataSource = friends;
            this.DataBind();
        }
    }
}