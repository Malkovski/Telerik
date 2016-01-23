using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployees
{
    public partial class EmployeesInRepeater : System.Web.UI.Page
    {
        NorthEntities content = new NorthEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var emps = this.content.Employees.AsQueryable().ToArray();

            this.EmployeeRepeater.DataSource = emps;
            this.EmployeeRepeater.DataBind();
        }
    }
}