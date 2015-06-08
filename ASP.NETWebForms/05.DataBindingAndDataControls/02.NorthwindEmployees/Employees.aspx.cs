using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.NorthwindEmployees
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
    }
}