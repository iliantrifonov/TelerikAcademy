using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SaveInputToSessionAndShowIt
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            var sessionText = Session["inputTextList"] as List<string>;
            if (sessionText == null)
            {
                sessionText = new List<string>();
            }

            sessionText.Add(this.TbInput.Text);
            this.TbInput.Text = "";
            Session["inputTextList"] = sessionText;

            this.LblResult.Text = string.Join(";   ", sessionText);
        }
    }
}