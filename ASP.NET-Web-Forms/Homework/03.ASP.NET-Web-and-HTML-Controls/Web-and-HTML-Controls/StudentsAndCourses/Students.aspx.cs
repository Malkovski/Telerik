using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var universities = new[] 
            {
                "UNSS",
                "NBU",
                "SU",
                "TU"
            };

            this.ddUniversities.DataSource = universities;
            this.ddUniversities.DataBind();

            var specialties = new[]
            {
                "Ovcharche",
                "Kozarche",
                "Cowboyche",
                "Kokoshkarche"
            };

            this.ddSpecialties.DataSource = specialties;
            this.ddSpecialties.DataBind();

            var courses = new[]
            {
                new { Id = 1, Name = "Mastering PBB (Prevodi ot bair na bair)" },
                new { Id = 2, Name = "Mastering LATP (Lead animals to pasha)" },
                new { Id = 3, Name = "Mastering TTV (Taking to vodopoi)" },
                new { Id = 4, Name = "Mastering AC (Animal care - doene, eggholding, brushing)"}
            };

            this.lbCourses.DataSource = courses;
            this.lbCourses.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fullname = this.tbFirstName.Text.ToString() + " " + this.tbLastName.Text.ToString();
            var number = this.tbFacultyNumber.Text.ToString();
            var uni = this.ddUniversities.SelectedItem;
            var spec = this.ddSpecialties.SelectedItem;
            string courses = "";

            foreach (ListItem item in this.lbCourses.Items)
            {
                if (item.Selected)
                {
                    courses += item.Text;
                    courses += " ";   
                }
            }

            this.LiteralResult.Text =
                "<h2>Name: " + fullname + "</h2><br/><p>Number: " + number + "</p>" +
                "<br/><p>" + uni + " with specialty - " + spec + " and courses:" + courses;
        }
    }
}