namespace NorthwindCustomers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using db;
    

    public partial class About : Page
    {
        NorthCustomers content = new NorthCustomers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var customers = content.Customers.AsQueryable().ToArray();

            this.GridViewCustomers.DataSource = customers;
            this.DataBind();
        }

        protected void GridViewCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var customers = content.Customers.AsQueryable().ToArray();

            this.GridViewCustomers.PageIndex = e.NewPageIndex;
            this.GridViewCustomers.DataSource = customers;
            this.DataBind();
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            var myGridResults = content.Customers.AsQueryable().ToArray();


            if (myGridResults != null)
            {
                var param = Expression.Parameter(typeof(Customer), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<Customer, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    this.GridViewCustomers.DataSource = myGridResults.AsQueryable<Customer>().OrderBy(sortExpression).ToList();
                    this.GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    this.GridViewCustomers.DataSource = myGridResults.AsQueryable<Customer>().OrderByDescending(sortExpression).ToList();
                    this.GridViewSortDirection = SortDirection.Ascending;
                }

                this.GridViewCustomers.DataBind();
            }
        }

    }
}