using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ButtonSumator(object sender, EventArgs e)
        {
            try
            {
                var first = decimal.Parse(this.tbFirstNuber.Text);
                var second = decimal.Parse(this.tbSecondNumber.Text);
                var sum = first + second;
                this.Sum.Text = sum.ToString();
            }
            catch (Exception)
            {

                this.Sum.Text = "invalid";

            }
            
        }
    }
}