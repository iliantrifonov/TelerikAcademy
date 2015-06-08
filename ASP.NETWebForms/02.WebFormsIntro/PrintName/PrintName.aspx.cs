using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintName
{
    public partial class PrintName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnterName_Click(object sender, EventArgs e)
        {
            this.lblShowName.Text = "Hello, " + this.tbName.Text;
        }
    }
}