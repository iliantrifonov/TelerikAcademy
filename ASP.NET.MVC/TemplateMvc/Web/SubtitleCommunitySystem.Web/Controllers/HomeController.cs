namespace Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Data;
    using Web.Controllers.Base;
    using Web.Filters;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}