namespace _02.NorthwindEmployees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class EmpDetails : System.Web.UI.Page
    {
        NorthwindEntities context;

        public EmpDetails()
        {
            this.context = new NorthwindEntities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public _02.NorthwindEmployees.Employee DvEmployee_GetItem([QueryString]int id)
        {
            return this.context.Employees.FirstOrDefault(a => id == a.EmployeeID);
        }
    }
}