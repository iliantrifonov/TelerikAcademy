using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebFormsAppForExplanation
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.lblHello.Text = "Hello, ASP.NET from the C# code";
            this.lblLocation.Text = Assembly.GetExecutingAssembly().Location;
        }
    }
}