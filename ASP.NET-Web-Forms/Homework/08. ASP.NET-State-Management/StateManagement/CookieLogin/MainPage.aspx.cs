using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookieLogin
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = this.Request.Cookies["UserName"];
            if (cookie == null)
            {
                this.Page.Response.Redirect("Login.aspx");
            }
        }
    }
}