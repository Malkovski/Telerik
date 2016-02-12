using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Caching_Data
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public  string DateEvery10Seconds(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}