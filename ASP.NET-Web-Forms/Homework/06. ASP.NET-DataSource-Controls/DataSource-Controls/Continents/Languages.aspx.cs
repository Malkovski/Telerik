namespace Continents
{
    using Continents.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Languages : Page
    {
        private ContinentsDbContext content;

        public Languages()
        {
            content = new ContinentsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Language> RepeaterLanguages_GetData()
        {
            return this.content.Languages.OrderBy(x => x.Id);
        }
    }
}