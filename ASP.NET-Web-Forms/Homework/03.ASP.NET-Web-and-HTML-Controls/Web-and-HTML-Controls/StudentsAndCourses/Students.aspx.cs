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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fullname = this.tbFirstName.Text.ToString() + " " + this.tbLastName.Text.ToString();
            var number = this.tbFacultyNumber.Text.ToString();
            var uni = this.ddUniversities.SelectedItem;
            var spec = this.ddSpecialties.SelectedItem;
            var courses = this.lbCourses.SelectedItem;

           

            this.LiteralResult.Text =
                "<h2>Name: " + fullname + "</h2><br/><p>Number: " + number + "</p>" +
                "<br/><p>" + uni + " with specialty - " + spec + " and courses:" +
                courses;
        }

        private void ShowResults()
        {
            
        }
    }
}