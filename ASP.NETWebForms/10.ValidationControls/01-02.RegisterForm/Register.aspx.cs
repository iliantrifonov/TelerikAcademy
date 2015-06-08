using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_02.RegisterForm
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLogon");

            this.Page.Validate("ValidationGroupPersonal");

            this.Page.Validate("ValidationGroupAddress");

            if (this.Page.IsValid)
            {
                //do useful things
            }
        }

        protected void CustomValidatorAcceptTerms_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CbAgree.Checked;
        }

        protected void BtnLogon_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLogon");
            if (!this.Page.IsValid)
            {
                this.LblLogonError.Text = "Logon group invalid.";
            }
        }

        protected void BtnPersonal_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupPersonal");
            if (!this.Page.IsValid)
            {
                this.LblPersonalError.Text = "Personal group invalid.";
            }
        }

        protected void BtnAddress_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupAddress");
            if (!this.Page.IsValid)
            {
                this.LblAddressError.Text = "Address group invalid.";
            }
        }
    }
}