using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionAppend
{
    public partial class MainPage : System.Web.UI.Page
    {
        private List<string> textItems = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["TextItems"] != null)
            {
                this.textItems = (List<string>)this.Session["TextItems"];

                foreach (var item in this.textItems)
                {
                    this.LabelOutput.Text += item;
                }
            }
        }

        protected void ButtonAddLoad_Click(object sender, EventArgs e)
        {
            this.textItems.Add(this.TextBoxInput.Text);
            this.Session["TextItems"] = this.textItems;

            this.LabelOutput.Text = string.Empty;

            foreach (var item in this.textItems)
            {
                this.LabelOutput.Text += item;
            }
        }
    }
}