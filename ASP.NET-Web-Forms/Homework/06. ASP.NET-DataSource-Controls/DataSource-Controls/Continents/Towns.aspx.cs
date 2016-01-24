using Continents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Continents
{
    public partial class Towns : System.Web.UI.Page
    {
        private ContinentsDbContext content;

        public Towns()
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
        public IQueryable<Town> ListViewTowns_GetData()
        {
            return this.content.Towns.OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewTowns_UpdateItem(int id)
        {
            Town item = this.content.Towns.Find(id);
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
        public void ListViewTowns_DeleteItem(int id)
        {
            Town item = this.content.Towns.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.content.Towns.Remove(item);
            this.content.SaveChanges();
        }
    }
}