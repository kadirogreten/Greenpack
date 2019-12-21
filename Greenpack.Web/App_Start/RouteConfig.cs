using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Greenpack.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
             name: "Menu",
             url: "{controller}/{action}/{title}",
             defaults: null,
             constraints: new { title = @"[a-zA-Z]+".Replace(" ", "-") } //Burada yönlendirmenin yapılabilmesi için
                                                                         //title verisinin yalnızca metinsel olmasını şart koştuk.

          );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Greenpack", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
