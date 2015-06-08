using System.Data.Entity;
using _02.NorthwindEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployeesRepeater
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
        public IQueryable<Employee> LvEmployees_GetData()
        {
            return this.context.Employees.AsQueryable().OrderBy(a=> a.EmployeeID);
        }
    }
}