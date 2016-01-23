namespace NorthwindEmployees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Details : System.Web.UI.Page
    {
        private NorthEntities employeesContent = new NorthEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Params["Id"] == null)
            {
                this.Response.Redirect("Employees.aspx");
            }

            var id = int.Parse(this.Request.Params["Id"]);
            var current = this.employeesContent.Employees.Where(x => x.EmployeeID == id).ToList();

            this.EmpDetails.DataSource = current;
            this.EmpDetails.DataBind();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Employees.aspx");
        }
    }
}