namespace Continents
{
    using Continents.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Countries : Page
    {
        private ContinentsDbContext content;

        public Countries()
        {
            content = new ContinentsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Country> GridViewCountries_GetData()
        {
            return this.content.Countries.OrderBy(x => x.Id); 
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCountries_UpdateItem(int id)
        {
            Country item = this.content.Countries.FirstOrDefault(x => x.Id == id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCountries_DeleteItem(int id)
        {
            Country item = this.content.Countries.FirstOrDefault(x => x.Id == id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.content.Countries.Remove(item);
            this.content.SaveChanges();
        }

    }
}