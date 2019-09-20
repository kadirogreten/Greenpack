using System.Web.Mvc;

namespace Greenpack.Web.Areas.AbatPanel
{
    public class AbatPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AbatPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AbatPanel_default",
                "AbatPanel/{controller}/{action}/{id}",
                new {controller = "kurumsalmenu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}