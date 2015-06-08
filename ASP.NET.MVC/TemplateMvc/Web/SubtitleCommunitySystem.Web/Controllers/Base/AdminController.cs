namespace Web.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data;
    using Web.Filters;
    using Web.Infrastructure.Constants;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IApplicationData data) : base(data)
        {
        }
    }
}