using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNumbersWebForms
{
    public partial class Sum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSum_Click(object sender, EventArgs e)
        {
            decimal firstNum;
            decimal secondNum;

            if (!decimal.TryParse(this.tbFirstNumber.Text, out firstNum) || !decimal.TryParse(this.tbSecondNumber.Text, out secondNum))
            {
                this.tbResult.Text = string.Empty;
                return;
            }

            var result = firstNum + secondNum;

            this.tbResult.Text = result.ToString();
        }
    }
}