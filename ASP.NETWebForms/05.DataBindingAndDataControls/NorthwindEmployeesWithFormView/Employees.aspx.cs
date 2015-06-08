using System.Data.Entity;
using _02.NorthwindEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployeesWithFormView
{
    public partial class Employees : System.Web.UI.Page
    {
        NorthwindEntities context;

        public Employees()
        {
            this.context = new NorthwindEntities();
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
        public IQueryable<_02.NorthwindEmployees.Employee> GvEmployees_GetData()
        {
            return context.Employees.OrderBy(e => e.EmployeeID).AsQueryable();
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Employee FvDetail_GetItem(int id)
        {
            return this.context.Employees.Find(id);
        }

        protected void GvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(this.GvEmployees.SelectedValue);
            this.FvDetail.DataSource = this.context.Employees.Where(a=> a.EmployeeID == id).ToList();
            this.FvDetail.DataBind();
        }
    }
}