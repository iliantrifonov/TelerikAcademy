using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.RedirectWithCookies
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                if (!string.IsNullOrWhiteSpace(Request.Cookies["username"].Value))
                {
                    Response.Redirect("~/Content.aspx");
                }
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            var username = this.TbUserName.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                return;
            }

            var cookie = new HttpCookie("username", username);
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.SetCookie(cookie);
            Response.Redirect("~/Content.aspx");
        }
    }
}