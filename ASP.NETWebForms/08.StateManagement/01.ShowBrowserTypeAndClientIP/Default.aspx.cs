using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.ShowBrowserTypeAndClientIP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            // If there is no proxy, get the standard remote address
            if (string.IsNullOrWhiteSpace(ip) || ip.ToLower() == "unknown")
            {
                ip = Request.ServerVariables["REMOTE_ADDR"];
            }

            var browser = this.Request.UserAgent;
            this.TbShow.Text = string.Format("Browser: {0}", browser);
            this.TbShowIp.Text = string.Format("Your IP: {0}", ip);
        }
    }
}