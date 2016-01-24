namespace TODOSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using TODOSystem.Models;
    using Microsoft.AspNet.Identity;

    public partial class Todos : Page
    {
         private TodoDbContext content;

         public Todos()
        {
            this.content = new TodoDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            var currentClass = this.TodoPanel.CssClass;
            if (currentClass == "hidden")
            {
                this.LinkButtonInsert.Text = "Close";
                this.TodoPanel.CssClass = "";
            }
            else
            {
                this.LinkButtonInsert.Text = "Add category";
                this.TodoPanel.CssClass = "hidden";
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Todo> ListViewTodos_GetData()
        {
            return this.content.Todos.OrderBy(x => x.Id);
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.content.Categories.OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewTodos_UpdateItem(int id)
        {
            Todo item = this.content.Todos.Find(id);
            var now = DateTime.Now;
            item.Date = now;
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
        public void ListViewTodos_DeleteItem(int id)
        {
            Todo item = this.content.Todos.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.content.Todos.Remove(item);
            this.content.SaveChanges();
        }

        public void ListViewTodos_InsertItem()
        {
            var item = new Todo();
            item.Date = DateTime.Now;
            item.UserId = this.User.Identity.GetUserId();

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.Todos.Add(item);
                this.content.SaveChanges();
            }
        }

        public void FormViewInsertTodo_InsertItem()
        {
            var item = new Todo();
            item.Date = DateTime.Now;
            item.UserId = this.User.Identity.GetUserId();

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.content.Todos.Add(item);
                this.content.SaveChanges();
            }
        }
    }
}