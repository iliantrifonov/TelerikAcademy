using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.ShowFromOneTextBoxInAnother
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            var text = Server.HtmlEncode(this.TbInput.Text);

            this.LblOutput.Text = text;
            this.TbOutput.Text = text;
        }
    }
}