using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenerateRandoms
{
    public partial class GenerateWithWebControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void generate_Click(object sender, EventArgs e)
        {
            var a = int.Parse(this.from.Text);
            var b = int.Parse(this.to.Text);
            var r = new Random();
            var res = r.Next(a, b);

            this.result.Text = "<h3>Yor lucky nimber is: <b>" + res + "</b></h3>";
        }
    }
}