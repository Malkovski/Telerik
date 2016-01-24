using Continents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Continents
{
    public partial class LanguageDetails : System.Web.UI.Page
    {
         private ContinentsDbContext content;

         public LanguageDetails()
        {
            content = new ContinentsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
         //or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Language LanguageDetail_GetItem([QueryString("id")]int? id)
        {
            var item = this.content.Languages.FirstOrDefault(z => z.Id == id);
            //var countriesCount = this.content.Countries.Where(x => x.Language.Name == item.Name).ToList().Count();
            //var townsCount = this.content.Towns.Where(x => x.Country.Language.Name == item.Name).ToList().Count();
            //var continentsCount = this.content.Continents.Where(x => x.Countries.Any(z => z.Language.Name == item.Name)).ToList().Count();


            return item;
        }
    }
}