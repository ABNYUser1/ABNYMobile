using System.Web.Mvc;

namespace ABNYMobile.Areas.m
{
    public class mAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "m";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "m_default",
                "m/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
