namespace NorthwindEmployees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class EmployeesListView : System.Web.UI.Page
    {
        NorthEntities content = new NorthEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var employees = this.content.Employees.AsQueryable().ToArray();

            this.EmployeeListView.DataSource = employees;
            this.EmployeeListView.DataBind();
        }

        protected void EmployeeListView_PagePropertiesChanged(object sender, EventArgs e)
        {
            var employees = this.content.Employees.AsQueryable().ToArray();

            this.EmployeeListView.DataSource = employees;
            this.EmployeeListView.DataBind();
        }
    }
}