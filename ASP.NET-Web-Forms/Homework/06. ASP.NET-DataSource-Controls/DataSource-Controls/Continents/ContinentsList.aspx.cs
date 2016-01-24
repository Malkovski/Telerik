using Continents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Continents
{
    public partial class ContinentsList : Page
    {
        private ContinentsDbContext content;

        public ContinentsList ()
        {
            content = new ContinentsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Continent> ListBoxContinents_SelectMethod()
        {
            return this.content.Continents.OrderBy(x=> x.Name);
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var continent = (ListBox)sender;
            var A = continent;
            //var current = this.content.Continents.FirstOrDefault(x => x.Id == continent.Id);
            //this.DetailsViewContinent.DataSource = current;
            //this.DetailsViewContinent.DataBind();
        }
    }
}