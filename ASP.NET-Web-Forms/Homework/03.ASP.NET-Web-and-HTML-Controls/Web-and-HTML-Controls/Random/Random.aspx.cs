using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Random
{
    public partial class Random : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_ServerClick(object sender, EventArgs e)
        {
            var from = decimal.Parse(this.lowRange.Value);
            var to = decimal.Parse(this.topRange.Value);
            Random random = new Random();
          
            Response.Write("Your lucky numbers is: <b>" + "AAAAAAAAAAAAAA" + "</b>");
        }
    }
}