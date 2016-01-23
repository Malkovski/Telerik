using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPages
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myProfile = new[]
            { 
                 new {fName = "Gosho", lName = "Peshov", status = "single", phone = 12345456767}
            };

            this.ListViewProfile.DataSource = myProfile;
            this.DataBind();
        }
    }
}