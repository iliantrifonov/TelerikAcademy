using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web
{
    public class BasePage
    {
        protected ApplicationDbContext DbContext { get; private set; }

        public BasePage()
        {
            this.DbContext = new ApplicationDbContext();
        }
    }
}