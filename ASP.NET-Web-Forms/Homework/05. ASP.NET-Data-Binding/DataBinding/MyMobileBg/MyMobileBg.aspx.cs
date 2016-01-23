namespace MyMobileBg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class MyMobileBg : System.Web.UI.Page
    {
        private Manufacturer[] mans = new Manufacturer[] 
            {
                new Manufacturer
                { 
                    Name = "BMW",
                    Models = new Model[]
                    { 
                        new Model { Name = "3" },
                        new Model { Name = "5" },
                        new Model { Name = "7" }
                    }
                },
                new Manufacturer 
                { 
                    Name = "Opel",
                    Models = new Model[] 
                    { 
                        new Model { Name = "Corsa" },
                        new Model { Name = "Astra" },
                        new Model { Name = "Vectra" } 
                    }
                },
                new Manufacturer 
                {
                    Name = "VW",
                    Models = new Model[]
                    {
                        new Model { Name = "Golf" },
                        new Model { Name = "Passat" },
                        new Model { Name = "Tuareg" }
                    }
                },
                new Manufacturer 
                { 
                    Name = "Ford",
                    Models = new Model[] 
                    { 
                        new Model { Name = "Mustang" },
                        new Model { Name = "Focus" },
                        new Model { Name = "Escort" }
                    }
                }
            };

        private Extras[] extras = new Extras[] 
        {
            new Extras { Name = "Climatronic"},
            new Extras { Name = "Parktronic"},
            new Extras { Name = "Stereo"},
            new Extras { Name = "Alarm"},
            new Extras { Name = "DVD/TV"},
            new Extras { Name = "Electronic mirros"},
            new Extras { Name = "Electronic windows"},
            new Extras { Name = "Navigation"}
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            this.Manufacturers.DataSource = this.mans;
            this.Manufacturers.DataBind();

            this.ExtrasList.DataSource = extras;
            this.ExtrasList.DataBind();

            var engineTypes = new string[] 
            {
                "Diesel",
                "Gasoline",
                "Electrical"
            };

            this.EngineTypesList.DataSource = engineTypes;
            this.EngineTypesList.DataBind();
        }

        protected void Manufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList selection = sender as DropDownList;

            if (selection == null)
            {
                return;
            }

            var models = this.GetModelsByManufacturer(selection.SelectedValue).ToArray();

            this.Models.DataSource = models;
            this.Models.DataBind();
        }

        private IEnumerable<string> GetModelsByManufacturer(string manufacturer)
        {
            var query = this.mans.FirstOrDefault(x => x.Name == manufacturer)
                .Models.Select(x => x.Name);
            return query;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var result = new StringBuilder();

            result.AppendLine("<b>Manufacturer: </b>" + this.Manufacturers.SelectedValue);
            result.AppendLine("<b>Model: </b>" + this.Models.SelectedValue);
            result.AppendLine("<b>Engine: </b>" + this.EngineTypesList.SelectedValue);

            var extrasList = string.Empty;

            foreach (ListItem item in this.ExtrasList.Items)
            {
                if (item.Selected)
                {
                    extrasList += item.Text + ", ";
                }
            }

            result.AppendLine("<b>Extras chosen: </b>" + extrasList.TrimEnd(' ').TrimEnd(','));

            this.ResultSelection.Text = result.ToString();
        }
    }
}