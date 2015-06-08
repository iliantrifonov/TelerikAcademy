﻿namespace Web.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data;

    [Authorize]
    public class AuthenticatedUserController : BaseController
    {
        public AuthenticatedUserController(IApplicationData data)
            : base(data)
        {
        }
    }
}