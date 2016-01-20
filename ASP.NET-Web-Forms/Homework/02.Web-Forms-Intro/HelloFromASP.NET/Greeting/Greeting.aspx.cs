namespace Greeting
{
    using System;
    using System.Linq;

    public partial class Greeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Greet(object sender, EventArgs e)
        {
            try
            {
                var hello = "From c#: Hello, ";
                var name = this.tbMyName.Text.ToString();
                this.greeting.Text = "<h1>" + hello + name + "</h1>";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}