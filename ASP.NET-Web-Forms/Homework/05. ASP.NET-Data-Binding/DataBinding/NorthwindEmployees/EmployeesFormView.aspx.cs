namespace NorthwindEmployees
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class EmployeesFormView : System.Web.UI.Page
    {
        private NorthEntities employeesContent = new NorthEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var emps = this.employeesContent.Employees.AsQueryable().ToArray();

            this.EmployeeFormView.DataSource = emps;
            this.EmployeeFormView.DataBind();
        }

        protected void EmployeeFormView_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            var emps = this.employeesContent.Employees.AsQueryable().ToArray();

            this.EmployeeFormView.PageIndex = e.NewPageIndex;
            this.EmployeeFormView.DataSource = emps;
            this.EmployeeFormView.DataBind();
        }
    }
}