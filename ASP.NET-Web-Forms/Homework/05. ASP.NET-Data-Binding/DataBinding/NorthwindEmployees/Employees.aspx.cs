namespace NorthwindEmployees
{
    using System;
    using System.Linq;

    public partial class Employees : System.Web.UI.Page
    {
        private NorthEntities employeesContent = new NorthEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var employees = this.employeesContent.Employees.AsQueryable().ToArray();

            this.EmployeeListGrid.DataSource = employees;
            this.EmployeeListGrid.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //var employees = this.employeesContent.Employees.AsQueryable().ToArray();

            //this.EmployeeListGrid.DataSource = employees;
            //this.EmployeeListGrid.DataBind();
        }
    }
}