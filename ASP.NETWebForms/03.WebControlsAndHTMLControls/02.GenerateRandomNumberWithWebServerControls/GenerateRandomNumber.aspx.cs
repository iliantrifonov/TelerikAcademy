using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.GenerateRandomNumberWithWebServerControls
{
    public partial class GenerateRandomNumber : System.Web.UI.Page
    {
        private Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            var from = Convert.ToInt32(this.TbFrom.Text);
            var to = Convert.ToInt32(this.TbTo.Text);

            var generatedNumber = this.rnd.Next(from, to + 1);
            this.LabelResult.Text = "<h1>The generated random number is: " + generatedNumber + "<h1 />";
            this.LabelResult.Visible = true;
        }
    }
}