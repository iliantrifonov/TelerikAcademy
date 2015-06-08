using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.MessagesService
{
    public partial class Default : System.Web.UI.Page
    {
        private MessagesContext context;

        public Default()
        {
            this.context = new MessagesContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LvMessages.DataSource = this.context.Messages.OrderBy(m => m.DatePublished).Take(100).ToList();
            this.LvMessages.DataBind();
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            this.LvMessages.DataSource = this.context.Messages.OrderByDescending(m => m.DatePublished).Take(100).ToList();
            this.LvMessages.DataBind();
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            var text = this.TbMessage.Text;
            var username = this.TbUsername.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var message = new Message()
            {
                Content = text,
                DatePublished = DateTime.Now,
                Username = username
            };

            this.context.Messages.Add(message);

            this.context.SaveChanges();

            this.TbMessage.Text = "";
        }
    }
}