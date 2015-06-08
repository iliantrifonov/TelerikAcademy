using System.Web.Mvc;

namespace Web.Areas.Teams
{
    public class PrivateAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Teams";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Teams_default",
                "Private/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}