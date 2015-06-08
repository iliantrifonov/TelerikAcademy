using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

namespace Chat
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Message> LvMessages_GetData()
        {
            return this.DbContext.Messages.OrderByDescending(m => m.DatePublished);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var author = this.DbContext.Users.Find(User.Identity.GetUserId());
            this.DbContext.Messages.Add(new Message()
            {
                Author = author,
                Content = TbMessage.Text,
                DatePublished = DateTime.Now,
            });

            this.DbContext.SaveChanges();
            this.Response.Redirect("~/");
        }
    }
}