using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.StudentRegistrationForm
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbCourses.SelectionMode = ListSelectionMode.Multiple;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var firstName = this.TbFirstName.Text;
            var lastName = this.TbLastName.Text;
            var fn = this.TbFacultyNumber.Text;
            var university = this.DdlUniversity.SelectedValue;
            var speciality = this.DdlSpeciality.SelectedValue;
            var courseIndices = this.LbCourses.GetSelectedIndices();
            var courses = new List<string>();
            for (int i = 0; i < courseIndices.Length; i++)
            {
                courses.Add(this.LbCourses.Items[courseIndices[i]].Value.ToString());
            }

            var coursesAsString = string.Join(", ", courses);

            if (IsCallback)
            {
                this.PanelResult.Controls.Clear();
            }

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "First Name: " + firstName
            });

            this.PanelResult.Controls.Add(new Panel());

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "Last Name: " + lastName
            });

            this.PanelResult.Controls.Add(new Panel());

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "Faculty number: " + fn
            });

            this.PanelResult.Controls.Add(new Panel());

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "University : " + university
            });

            this.PanelResult.Controls.Add(new Panel());

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "Speciality: " + speciality
            });

            this.PanelResult.Controls.Add(new Panel());

            this.PanelResult.Controls.Add(new Literal()
            {
                Text = "Courses: " + coursesAsString
            });
        }
    }
}