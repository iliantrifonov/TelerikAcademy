using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.GenerateRandomNumberHtmlControls
{
    public partial class _Default : Page
    {
        private Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRandom_ServerClick(object sender, EventArgs e)
        {
            var from = Convert.ToInt32(this.inputFrom.Value);
            var to = Convert.ToInt32(this.inputTo.Value);

            var generatedNumber = this.rnd.Next(from, to + 1);
            Response.Write("<h1>The generated random number is: " + generatedNumber + "<h1 />");
        }
    }
}