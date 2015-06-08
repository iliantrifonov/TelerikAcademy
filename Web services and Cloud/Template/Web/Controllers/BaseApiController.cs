namespace Web.Controllers
{
    using Data;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected IApplicationData data;

        public BaseApiController(IApplicationData data)
        {
            this.data = data;
        }
    }
}
