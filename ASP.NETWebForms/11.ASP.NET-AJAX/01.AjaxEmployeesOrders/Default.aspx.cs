using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.AjaxEmployeesOrders
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindEntities context;

        public Default()
        {
            this.context = new NorthwindEntities();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.RebindOrders();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employee> GvEmployees_GetData()
        {
            var employees = this.context.Employees.OrderBy(e => e.EmployeeID);
            return employees;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Order> GvOrders_GetData()
        {
            var selectedEmployee = this.GvEmployees.SelectedValue as Employee;
            if (selectedEmployee == null)
	        {
                        return null;
	        }

            var orders = this.context.Orders.Where(o => o.Employee == selectedEmployee).OrderBy(o => o.OrderID);
            return orders;
        }

        protected void GvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            this.RebindOrders();
        }

        protected void GvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GvOrders.PageIndex = e.NewPageIndex;
            this.RebindOrders();
        }

        private void RebindOrders()
        {
            int employeeId = Convert.ToInt32(this.GvEmployees.SelectedValue);
            var context = new NorthwindEntities();
            this.GvOrders.DataSource = context.Orders.Where(o => o.EmployeeID == employeeId).ToList();
            this.GvOrders.DataBind();
        }
    }
}