using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Chat
{
    public class BasePage : Page
    {
        public BasePage()
        {
            this.DbContext = new ApplicationDbContext();
        }

        protected ApplicationDbContext DbContext { get; set; }
    }
}