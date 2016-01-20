using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escaping
{
    public partial class EscapingExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowText_Click(object sender, EventArgs e)
        {
            var input = this.InputText.Text;
            this.LiteralText.Text = Server.HtmlEncode(input);
            this.EscapedText.Text = Server.HtmlEncode(input);
        }
    }
}