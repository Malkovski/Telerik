namespace Continents
{
    using Continents.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;

    public partial class CountryDetails : Page
    {
        private ContinentsDbContext content;

        public CountryDetails()
        {
            content = new ContinentsDbContext();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Country FormViewCountryDetails_GetItem([QueryString("id")]int? id)
        {
            var country = this.content.Countries.FirstOrDefault(x => x.Id == id);
            return country;
        }

    }
}