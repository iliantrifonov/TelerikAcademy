using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

namespace Chat.Moderation
{
    public partial class Edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
            this.Response.Redirect("~/Moderation/Edit.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LvMessages_UpdateItem(int id)
        {
            Message item = this.DbContext.Messages.Find(id);

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                this.DbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LvMessages_DeleteItem(int id)
        {
            var item = this.DbContext.Messages.Find(id);
            this.DbContext.Messages.Remove(item);
            this.DbContext.SaveChanges();
        }
    }
}