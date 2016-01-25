﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookieLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = this.Request.Cookies["UserName"];
            if (cookie != null)
            {
                this.Page.Response.Redirect("Main.aspx");
            }
        }

        protected void ButtonLogMe_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserName", "You are logged in!");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            this.Response.Cookies.Add(cookie);

            this.Page.Response.Redirect("Main.aspx");
        }
    }
}