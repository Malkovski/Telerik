using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenerateRandoms
{
    public partial class GenerateWithHtmlControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_ServerClick(object sender, EventArgs e)
        {
            var a = int.Parse(this.lowRange.Value);
            var b = int.Parse(this.topRange.Value);
            var r = new Random();
            var res = r.Next(a, b);

            Response.Write("Yor lucky nimber is: <b>" + res + "</b>");
        }
    }
}