namespace Continents
{
    using Continents.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class TownDetails : Page
    {
        private ContinentsDbContext content;

        public TownDetails()
        {
            content = new ContinentsDbContext();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Town FormViewTownDetails_GetItem([QueryString("id")]int? id)
        {
            var town = this.content.Towns.FirstOrDefault(x => x.Id == id);

            return town;
        }
    }
}